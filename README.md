# ⚔️ CombatCore

Sistema de combate RPG em turnos desenvolvido em C# com foco em Programação Orientada a Objetos (POO), arquitetura de software, modularização e modelagem de sistemas de gameplay.

---

# 📖 Sobre o projeto

O CombatCore começou como um projeto de treino em C# e evoluiu para um sistema modular de combate RPG baseado em turnos.

O principal objetivo do projeto é praticar conceitos fundamentais e intermediários de desenvolvimento backend utilizando C# e .NET, aplicando organização de código, separação de responsabilidades e construção progressiva de sistemas escaláveis.

Atualmente, o projeto possui:

* Sistema completo de combate em turnos
* Sistema modular de ações, habilidades e efeitos
* Classes jogáveis com comportamentos distintos
* Sistema de efeitos contínuos
* Sistema contextual de tomada de decisão para IA
* Estrutura baseada em interfaces, composição e herança
* Organização arquitetural focada em escalabilidade

---

# ⚙️ Funcionalidades

## ⚔️ Sistema de combate

* Combate baseado em turnos
* Ataques básicos
* Skills especiais
* Ataques críticos
* Chance de erro
* Execução modular de combate
* Fluxo centralizado de turnos

---

## 🧙 Classes jogáveis

* Guerreiro
* Mago
* Arqueiro

Cada classe possui:

* Ataque básico próprio
* Skills exclusivas
* Comportamento estratégico diferente
* Prioridades específicas de combate

---

## 🧪 Sistema de efeitos

* Queimadura
* Envenenamento
* Atordoamento
* Cura

Os efeitos possuem:

* Duração por turnos
* Aplicação automática
* Remoção automática
* Processamento separado do fluxo principal de combate

---

## 🧠 Sistema de IA

O CombatCore possui um sistema inicial de tomada de decisão contextual para personagens controlados pela IA.

Os personagens podem:

* Avaliar a própria vida
* Avaliar a situação do inimigo
* Escolher entre ataques básicos e habilidades
* Priorizar dano, controle ou sobrevivência
* Tomar decisões baseadas no estado atual do combate

Atualmente:

* Guerreiros possuem comportamento mais agressivo
* Arqueiros priorizam controle e atordoamento
* Magos possuem comportamento mais imprevisível e focado em habilidades

O sistema também possui:

* Avaliação estratégica de dano
* Escolha automática de habilidades
* Separação entre cálculo estratégico e execução real de ações

---

# 🎮 Demonstração

---![Combat Demo](./assets/combat-demo.gif)

# 🧱 Arquitetura do projeto

O projeto foi organizado com foco em modularização e separação de responsabilidades.

## Interfaces

* `IAction` → ataques básicos
* `ISkill` → habilidades especiais
* `IEffect` → efeitos contínuos

---

## Entidades principais

### `Character`

Responsável por:

* Estado do personagem
* Vida e atributos
* Inventário de skills
* Efeitos ativos
* Sistema de decisão contextual
* Avaliação estratégica de ações

---

### `CombatLog`

Responsável por:

* Exibição visual do combate
* Logs de ações
* Logs de habilidades
* Logs de efeitos
* Feedback visual do sistema

---

### `Program`

Responsável por:

* Fluxo principal da batalha
* Controle de turnos
* Execução do combate
* Coordenação geral do sistema

---

## Organização de módulos

* Actions
* Skills
* Effects
* Logs
* Classes
* Core do combate

---

# 📂 Estrutura do projeto

```bash
CombatCore/
│
├── Actions/
│   ├── IAction.cs
│   │
│   ├── ArcherActions/
│   ├── MageActions/
│   └── WarriorActions/
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
│   ├── ArrowSkills/
│   ├── MagicSkills/
│   └── SwordSkills/
│
├── Logs/
│   └── CombatLog.cs
│
├── Classes/
│   ├── Warrior.cs
│   ├── Mage.cs
│   └── Archer.cs
│
├── Character.cs
├── Program.cs
└── README.md
```

---

# 🛠️ Tecnologias utilizadas

* C#
* .NET
* Console Application
* Git
* GitHub

---

# 🚀 Como executar

## Pré-requisitos

* .NET SDK instalado

---

## Clonando o projeto

```bash
git clone https://github.com/geraldimatheus/combat-core.git
```

---

## Executando

```bash
cd combat-core
dotnet run
```

---

# 📚 Conceitos praticados

* Programação Orientada a Objetos
* Encapsulamento
* Interfaces
* Herança
* Classes abstratas
* Composição
* Organização de namespaces
* Modularização de sistemas
* Arquitetura de software
* Separação de responsabilidades
* Sistemas baseados em turnos
* Modelagem de gameplay
* IA baseada em comportamento contextual
* Avaliação estratégica de ações
* Estruturação de sistemas escaláveis

---

# 📈 Evolução do Projeto

## Principais evoluções implementadas

* Modularização do sistema de combate
* Separação entre ações, habilidades e efeitos
* Implementação de sistema centralizado de logs
* Sistema automático de efeitos contínuos
* Sistema contextual de IA para combate
* Integração da IA ao fluxo principal da batalha
* Diferenciação comportamental entre classes
* Sistema de avaliação estratégica de dano
* Separação entre cálculo e execução de habilidades
* Melhorias estruturais no pipeline de turnos
* Organização progressiva da arquitetura do projeto

---

# 🔮 Melhorias futuras

* Sistema de inventário
* Sistema de mana
* Sistema de níveis
* Equipamentos
* Sistema de atributos
* Persistência de save
* Interface gráfica
* Multiplayer local
* Novas classes
* Novos efeitos e habilidades
* Especialização comportamental por classe
* Refatoração do sistema de decisão usando polimorfismo

---

# 👨‍💻 Autor

Projeto desenvolvido por Matheus Geraldi como parte dos estudos em C# e desenvolvimento de sistemas.

## 📫 Contato

* LinkedIn: https://www.linkedin.com/in/geraldimatheus/
* GitHub: https://github.com/geraldimatheus
