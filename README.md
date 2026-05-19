# ⚔️ CombatCore

Sistema de combate RPG em turnos desenvolvido em C# com foco em Programação Orientada a Objetos (POO), organização de código e separação de responsabilidades.

---

## 📖 Sobre o projeto

O CombatCore começou como um projeto de treino em C# e evoluiu para uma estrutura modular de combate RPG baseada em turnos.

O projeto foi desenvolvido com o objetivo de praticar:
- Programação Orientada a Objetos
- Interfaces
- Polimorfismo
- Organização de projeto
- Separação de responsabilidades
- Estruturação de sistemas escaláveis

---

## ⚙️ Funcionalidades

### ⚔️ Sistema de combate
- Combate em turnos
- Ataques físicos
- Ataques mágicos
- Ataques críticos
- Chance de erro

### 🧪 Sistema de efeitos
- Queimadura
- Veneno
- Atordoamento
- Cura

### 🧱 Estrutura modular
- Interfaces para ações e efeitos
- Separação entre Actions, Effects e Skills
- Sistema expansível para novas habilidades

---

## 🛠️ Tecnologias utilizadas

- C#
- .NET
- Console Application

---

## 📂 Estrutura do projeto

```bash
CombatCore/
│
├── Actions/
│   ├── IAction.cs
│   │
│   ├── ArcherActions/
│   │   ├── ArcherAttack.cs
│   │   └── BasicArcherAttack.cs
│   │
│   ├── MageActions/
│   │   ├── MageAttack.cs
│   │   └── BasicMageAttack.cs
│   │
│   └── WarriorActions/
│       ├── WarriorAttack.cs
│       └── BasicWarriorAttack.cs
│
├── Effects/
│   ├── IEffect.cs
│   ├── BurnEffect.cs
│   ├── PoisonEffect.cs
│   ├── StunEffect.cs
│   └── HealEffect.cs
│
├── Skills/
│   ├── ISkill.cs
│   ├── FireSwordAttack.cs
│   ├── PoisonSwordAttack.cs
│   └── StunSwordAttack.cs
│
├── Character.cs
├── Program.cs
├── CombatCore.csproj
└── README.md

---

## 🚀 Como executar

### Pré-requisitos
- .NET SDK instalado

### Clonando o projeto

```bash
- git clone https://github.com/SEU-USUARIO/CombatCore.git

### Executando
- cd CombatCore
- dotnet run

---

## 📚 Conceitos praticados
- Classes e Objetos
- Encapsulamento
- Interfaces
- Polimorfismo
- Listas Genéricas
- Estruturação de sistemas
- Organização de namespaces
- Separação de responsabilidades
- Lógica de combate RPG

---

##🔮 Melhorias futuras
- Sistema de inventário
- Sistema de mana
- IA para inimigos
- Sistema de níveis
- Equipamentos
- Interface gráfica
- Persistência de save
- Mais classes e habilidades

---

## 👨‍💻 Autor

- Projeto desenvolvido por Matheus Geraldi como parte dos estudos em C# e desenvolvimento de sistemas.