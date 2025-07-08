# 🧠 Hunter Assassin – State Machine System (Unity, C#)

This project demonstrates the application of the **State Machine Design Pattern** to manage AI behaviors across different enemy types in Unity. The goal was to break complex logic into modular, manageable states, improving maintainability, scalability, and clarity of the enemy behavior system.

---

## Gameplay

Click on following image to view gameplay.
[![Image](https://github.com/user-attachments/assets/dada502e-a444-479e-9f75-2bdf9e34172f)](https://drive.google.com/file/d/1a2acydaArqbE9yULvaZO7UegSZZRBR6w/view?usp=sharing)


---

## 🚀 Development Journey

I began by implementing a basic state machine for a single enemy type to understand the core mechanics of state-based logic. Once confident, I built a **generic State Machine system** that stores a reference to the **owner** (e.g., `EnemyController`) for contextual access inside each state.

This generic system was then extended to support multiple enemy types — some **sharing states** like Idle or Patrol, and others with **unique behaviors** like Teleporting or Cloning. The flexibility of this architecture allowed for reuse, customization, and clean separation of responsibilities.

---

## 🎯 Objective

To design a modular enemy AI framework using a **generic State Machine** where:
- States are isolated and reusable.
- Each state can access the owner context.
- Enemy-specific behavior can extend or override shared states.

---

## 🔄 Enemy States Implemented

- `IdleState` – Wait or remain stationary.
- `PatrolState` – Move between waypoints or positions.
- `ChaseState` – Pursue the player if within a certain range.
- `ShootState` – Fire projectiles or attack from distance.
- `TeleportState` – Instantly relocate to a new location.
- `CloneState` – Spawn a duplicate enemy.

---

## 🧠 What I Learned

- Built an **owner-aware generic State Machine** class in C#.
- Applied **inheritance and interface-based programming** to design flexible AI systems.
- Separated logic clearly using **SRP (Single Responsibility Principle)**.
- Reused states across enemy types while supporting enemy-specific state behaviors.
- Developed **data-driven AI behaviors** with clean state transitions and decoupled logic.

---

## 🧩 Design Pattern Used

- **State Machine Pattern** for managing behavior transitions.

---

## 🛠️ Technologies Used

- Unity (C#)
- Visual Studio
- Git for version control


