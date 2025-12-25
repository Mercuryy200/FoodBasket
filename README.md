# Food Basket Game

An interactive Unity game where players catch falling food items in a pot while avoiding bombs. The game features progressive difficulty scaling, smooth animations, and comprehensive testing practices.

![Game Screenshot](todo)

## Game Overview

Food Basket is a fast-paced arcade-style game built with Unity and C#. Players must catch falling food items in a pot while avoiding bombs. As time progresses, the game becomes increasingly challenging with faster falling speeds and more frequent spawns.

## Features

- **Dynamic Gameplay**: Food items and bombs spawn from above with realistic physics
- **Progressive Difficulty**: Game speed increases as the timer counts down
- **Score System**: Track your performance with real-time score updates
- **Game States**: Complete game flow with start, play, game over, and restart functionality
- **Physics-Based**: Utilizes Unity's Rigidbody system for realistic falling mechanics
- **Polished UI**: Clean interface built with TextMesh Pro
- **Audio & Visual Effects**: Immersive sound effects and particle effects
- **Comprehensive Testing**: Unit tests, play mode tests, and configuration tests included

## Technologies & Concepts

- **Engine**: Unity 
- **Language**: C#
- **Assets**: Unity Asset Store
- **UI**: TextMesh Pro
- **Physics**: Rigidbody, Collision Detection
- **Programming Concepts**:
  - Coroutines for asynchronous operations
  - Custom gravity manipulation
  - Prefab-based architecture
  - Event-driven programming
- **Testing**:
  - Unity Test Framework
  - Unit Tests
  - Play Mode Tests
  - Configuration Tests

## How to Play

1. Press **Start** to begin the game
2. Use **Arrow Keys** or **A/D** to move the pot left and right
3. Catch falling food items to increase your score
4. Avoid catching bombs - you lose points!
5. Survive as long as possible before the timer runs out
6. Try to beat your high score!

## Getting Started

### Prerequisites

- Unity (Version 6.0 or higher) 
- Git

### Installation

1. Clone the repository:
```bash
git clone https://github.com/Mercuryy200/FruitBasket.git
```

2. Open Unity Hub

3. Click "Add" and navigate to the cloned project folder

4. Open the project with your Unity version

5. Open the main scene located at `Assets/Scenes/MainScene.unity`

6. Press the Play button to start the game

## Running Tests

This project includes comprehensive tests to ensure code quality.

### Running Unit Tests

1. Open Unity Test Runner: `Window > General > Test Runner`
2. Select the **EditMode** tab
3. Click **Run All** to execute unit tests

### Running Play Mode Tests

1. In the Test Runner window, select the **PlayMode** tab
2. Click **Run All** to execute play mode tests

### Running Configuration Tests

Configuration tests verify that game settings and prefabs are properly configured.

## 📁 Project Structure
```
FoodBasket/
├── Assets/
│   ├── Scenes/          # Game scenes
│   ├── Scripts/         # C# scripts
│   │   ├── GameManager.cs
│   │   ├── SpawnManager.cs
│   │   ├── PlayerController.cs
│   │   └── ...
│   ├── Prefabs/         # Game object prefabs
│   ├── Materials/       # Materials and textures
│   ├── Audio/           # Sound effects and music
│   ├── VFX/             # Visual effects
│   └── Tests/           # Test scripts
├── Packages/
└── ProjectSettings/
```

## Learning Outcomes

This project demonstrates proficiency in:

- Unity game development fundamentals
- C# programming and OOP principles
- Physics simulation and collision detection
- UI/UX design with TextMesh Pro
- Asynchronous programming with Coroutines
- Test-driven development (TDD)
- Game state management
- Performance optimization

## Configuration

Key game settings can be adjusted in the Inspector:

- **Spawn Rate**: Adjust frequency of falling items
- **Difficulty Scaling**: Modify how quickly the game gets harder
- **Timer Duration**: Set the game length
- **Gravity Multiplier**: Control falling speed

## Known Issues

- None at the moment

## Future Enhancements

- [ ] Add power-ups (slow motion, shield, etc.)
- [ ] Implement high score persistence with PlayerPrefs
- [ ] Add multiple difficulty levels
- [ ] Include different game modes
- [ ] Add more food and bomb varieties
- [ ] Implement combo system for consecutive catches

## Author

**Rima Nafougui**

- Portfolio: [rimanafougui.vercel.app](https://rimanafougui.vercel.app)
- GitHub: [@Mercuryy200](https://github.com/Mercuryy200)
- LinkedIn: [Rima Nafougui](https://linkedin.com/in/rima-nafougui-b0434b295/) 

## Acknowledgments

- Unity Asset Store for game assets
- Unity Documentation and Community

## Screenshots

### Main Menu
![Main Menu](todo)

### Gameplay
![Gameplay](todo)

### Game Over Screen
![Game Over](todo)

---

⭐ If you found this project interesting, please consider giving it a star!
