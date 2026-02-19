Boa ideia — aprender POO construindo **um único projeto que evolui** é uma das formas mais eficientes de entender os conceitos. Abaixo está uma sequência de exercícios em que você vai **expandindo o mesmo sistema**, adicionando recursos passo a passo. Cada etapa depende da anterior.

A história base: você vai criar um pequeno **simulador de macacos coletando e gerenciando bananas**.

---

## 🟢 Exercício 1 — Primeira classe

Crie uma classe que represente um macaco.

**Objetivo:**

* Criar atributos
* Instanciar objetos

**Requisitos:**

* Classe `Macaco`
* Atributos:

  * Nome
  * QuantidadeDeBananas
* Método:

  * `PegarBanana()` → aumenta a quantidade

**Desafio extra:**

* Criar 2 macacos no `Main` e testar.

---

## 🟢 Exercício 2 — Métodos com regras

Agora o macaco pode comer bananas.

**Adicionar:**

* Método `ComerBanana()`

  * Só pode comer se tiver bananas
  * Mostrar mensagem adequada

**Você aprende:**

* Lógica interna da classe
* Proteção de estado

---

## 🟡 Exercício 3 — Encapsulamento

Impeça que qualquer parte do programa altere as bananas diretamente.

**Modificar:**

* Tornar atributos privados
* Criar propriedades (`get/set`)

**Regra:**

* Não permitir valores negativos

---

## 🟡 Exercício 4 — Construtor

Agora o macaco nasce com dados definidos.

**Adicionar:**

* Construtor que recebe:

  * Nome
  * Bananas iniciais

**Desafio:**

* Criar vários macacos com estados diferentes

---

## 🟡 Exercício 5 — Interação entre objetos

Macacos podem trocar bananas.

**Adicionar método:**

```
DarBanana(Macaco outroMacaco, int quantidade)
```

**Regras:**

* Não pode doar mais do que possui
* Atualizar ambos os macacos

Aqui você aprende:

✔ comunicação entre objetos
✔ responsabilidade de classe

---

## 🟠 Exercício 6 — Classe Banana

Agora bananas viram objetos!

Crie:

* Classe `Banana`

  * Tipo (Prata, Nanica, Ouro…)
  * Energia

Macaco agora:

* Possui lista de bananas
* Come bananas específicas

Você aprende:

✔ composição
✔ listas de objetos

---

## 🟠 Exercício 7 — Inventário

Macaco possui mochila.

Adicionar:

* Limite de bananas
* Método para armazenar
* Ver inventário

Aqui entra:

✔ controle de coleção
✔ validações

---

## 🔵 Exercício 8 — Herança

Crie tipos de macacos:

* `MacacoComum`
* `MacacoNinja`

MacacoNinja:

* Come banana → ganha bônus
* Pode roubar banana

Você aprende:

✔ herança
✔ sobrescrita

---

## 🔵 Exercício 9 — Polimorfismo

Todos os macacos têm:

```
ExecutarAcao()
```

Cada tipo faz algo diferente:

* Comer
* Roubar
* Coletar

Você aprende:

✔ comportamento dinâmico

---

## 🔴 Exercício 10 — Sistema completo

Criar:

* Classe `Selva`
* Lista de macacos
* Rodadas automáticas

A cada rodada:

* Macacos agem
* Bananas circulam
* Relatório final

Você aprende:

✔ organização de sistema
✔ interação de múltiplas classes

---

## ⭐ Desafio final (opcional)

Adicionar:

* Pontos de energia
* Banana especial
* Eventos aleatórios

---

Se quiser, posso te mostrar:

✅ Estrutura inicial do projeto
✅ Diagrama mental das classes
✅ Primeiro exercício com código guiado
✅ Versão desafio hardcore
✅ Explicação de cada conceito
✅ Próximo nível com interfaces
✅ Simulação estilo jogo

É só me dizer o que você quer seguir.
