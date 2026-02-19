Com certeza. Para transformar esse código em uma arquitetura limpa, profissional e fácil de manter, vamos seguir um roteiro que ataca os problemas de **Acoplamento** (dependências fortes) e **Responsabilidade Única** (quem faz o quê).

Aqui está o seu **Checklist de Refatoração Passo a Passo**:

---

### ✅ Passo 1: Desacoplar as Entidades (Domain Isolation)

As classes de domínio (`Macaco`, `Banana`, `Bolsa`) não devem saber que existe uma `Floresta` ou um banco de dados. Elas devem apenas cuidar de suas próprias propriedades.

* [ ] **Refatorar `Macaco.SoltarBolsa()**`:
* Atualmente: Ele chama `Floresta.ReceberBolsa(BolsaVestida)`.
* **Ação**: Faça o método retornar a `Bolsa` e remova a chamada à `Floresta`.
* *Por que?* O macaco apenas tira a bolsa. Quem decide onde a bolsa vai (no chão, no lixo, na mão de outro macaco) é quem está controlando o jogo.


```csharp
// Como deve ficar em Macaco.cs
public Bolsa SoltarBolsa()
{
    if (BolsaVestida == null) throw new InvalidOperationException("...");

    var bolsa = BolsaVestida;
    BolsaVestida = null; 
    return bolsa; // Retorna o objeto, não chama a Floresta
}

```



---

### ✅ Passo 2: Eliminar o "Global State" (Static)

Classes estáticas que guardam dados (`static class Floresta`) são vilãs em testes e manutenção. Vamos transformá-la em um objeto real.

* [ ] **Remover `static` da classe `Floresta**`:
* **Ação**: Mude `static class Floresta` para `public class Floresta`.
* **Ação**: Remova `static` de todas as listas e métodos internos dela (`_macacos`, `AdicionarMacaco`, etc.).


* [ ] **Injetar a Dependência**:
* No `Program.cs`, crie uma instância única: `Floresta floresta = new Floresta();`.
* Passe essa instância `floresta` para o seu `MainController`.



---

### ✅ Passo 3: Separar UI de Lógica (Services)

Este é o passo mais importante para o **SRP (Single Responsibility Principle)**. Seus Services não podem ter `Console.ReadLine` ou `WriteLine`.

* [ ] **Limpar `BananaServices`, `MacacoServices`, `BolsaServices**`:
* **Ação**: Mude a assinatura dos métodos. Em vez de `void CadastrarBanana()`, use `void CriarBanana(string tipo, int energia)`.
* **Ação**: Mova todo o `Console.ReadLine` para o `MainController`. O Service só recebe os dados prontos e adiciona na `Floresta`.


*Exemplo Prático (BananaServices):*
```csharp
// BananaServices.cs (Limpo)
public class BananaServices 
{
    private readonly Floresta _floresta;

    public BananaServices(Floresta floresta) {
        _floresta = floresta;
    }

    public void CriarBanana(string tipo, int energia) {
        // Apenas validação de negócio e persistência
        _floresta.AdicionarBanana(tipo, energia);
    }
}

```



---

### ✅ Passo 4: Centralizar a Interação no Controller

Agora que seus Services são puros (só lógica), o `MainController` assume o papel de "Frontend" (Interação com o usuário).

* [ ] **Atualizar `MainController.CadastrarBanana()**`:
* **Ação**: É aqui que você pede os dados ao usuário.


```csharp
public void CadastrarBanana()
{
    Console.Write("Tipo: ");
    string tipo = Console.ReadLine();

    Console.Write("Energia: ");
    int energia = int.Parse(Console.ReadLine());

    // Chama o serviço passando os dados limpos
    _bananaServices.CriarBanana(tipo, energia); 

    Console.WriteLine("Sucesso!");
}

```



---

### ✅ Passo 5: Padronização de Código (Clean Code)

Ajuste os nomes para seguir as convenções do C# (.NET naming conventions).

* [ ] **Variáveis Locais em camelCase**:
* Mude `Macaco NovoMacaco` para `Macaco novoMacaco`.
* Mude `string Opcao` para `string opcao`.
* PascalCase (letra maiúscula no início) só para **Classes**, **Métodos** e **Propriedades Públicas**.


* [ ] **Remover "Magic Strings"**:
* No `switch(Opcao)`, use constantes ou um `Enum` em vez de "1", "2", "3".
* Exemplo: `case MenuOption.CadastrarMacaco: ...`



---

### Resumo Visual da Nova Arquitetura

Depois dessas mudanças, o fluxo de dependência ficará assim (respeitando arquitetura em camadas):

1. **Program.cs** (Cria a `Floresta`, cria os `Services` injetando a floresta, cria o `Controller`).
2. **Controller** (Fala com o Usuário `Console` + Chama os Services).
3. **Services** (Executam regras de jogo + Chamam a Floresta/Entidades).
4. **Floresta** (Guarda os dados - é o "Banco de Dados" em memória).
5. **Entidades** (Macaco, Bolsa, Banana - Regras puras, não conhecem ninguém acima delas).

Quer ajuda para reescrever alguma classe específica seguindo esse modelo?