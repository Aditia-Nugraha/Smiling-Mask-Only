# Smile Mask Only 🎭

**Smile Mask Only** is a 2D game developed using Unity during **Global Game Jam 2026** by **Nova Games**, based on the theme **"Mask"**.

In a world where only smiling masks are allowed to enter the house, the player is tasked with protecting the house by **letting Smile Masks enter** while **shooting Not Smile Masks**. The player must make quick decisions as masks continuously approach from both sides of the screen.

## 🎮 Gameplay

The player stands in the center of the screen and can move left and right to position themselves and aim their shots.

* 😊 **Smile Mask** → Let it enter the house.
* 😠 **Not Smile Mask** → Shoot it before it reaches the house.
* 🎯 Shooting a Smile Mask → **Game Over**.
* 🏠 Allowing a Not Smile Mask to enter the house → **Game Over**.

As the score increases, the game becomes more challenging through faster mask movement and additional Not Smile Mask variations.

## ✨ Features

* 🎭 Smile Mask and multiple Not Smile Mask variations
* 🔫 Shooting system
* ↔️ Left and right player movement
* 🏠 Mask spawning from both sides
* 📈 Progressive difficulty based on score
* 🏆 Score system
* 💥 Floating score effects
* 🎵 Background music and sound effects
* 🎬 Player and mask animations
* 💀 Game Over screen with the reason for defeat
* 🔄 Play Again and Main Menu

## 🕹️ Controls

| Input               | Action     |
| ------------------- | ---------- |
| `A`                 | Move Left  |
| `D`                 | Move Right |
| `Space`             | Shoot      |
| `Left Mouse Button` | Shoot      |

## 📥 Download

The latest playable build is available on the **GitHub Releases** page.

👉 **[⬇️ Download Latest Release](../../releases/latest)**

Download the latest release and extract the ZIP file before running the game.

## 💻 Installation

### Windows

1. Download the latest release from the **[GitHub Releases](../../releases/latest)** page.
2. Download the `.zip` file containing the game.
3. Extract the ZIP file to a location of your choice.
4. Open the extracted game folder.
5. Run the `.exe` file to start the game.
6. Enjoy **Smiling Mask Only**! 🎭

> **Note:** Keep the `.exe` file and its accompanying game data folder in the same directory. Do not move or delete individual files from the extracted folder.

## 🛠️ Built With

* **Unity**
* **C#**
* **Unity Animator**
* **TextMeshPro**
* **Unity Legacy Input System**

## 📂 Project Structure

The main project structure is organized as follows:

```text
Assets/
├── Environment/
│   ├── MainMenu/
├── Logo/
├── Prefabs/
├── Scenes/
├── Scripts/
├── Settings/
├── Sounds/
│   ├── BGM/
├── Sprites/
│   ├── Mask/
└── .../
```

Some of the main scripts used in the project include:

```text
PlayerMovement
MaskSpawner
MaskMovement
Bullet
GameManager
GameOverUI
MainMenuUI
FloatingScore
```

## 🚀 Running the Project

To run the project in Unity:

1. Clone or download this repository.
2. Open the project using **Unity**.
3. Open the **MainMenuScene**.
4. Press the **Play** button in the Unity Editor.

> Use the Unity version that was used during development to minimize compatibility issues.

## 📸 Screenshots

![image](https://github.com/Aditia-Nugraha/Smiling-Mask-Only/blob/7543286de1c97a1bda023a01bfe38ead3ce160b5/Screenshot%202026-04-01%20073614.png)
![image](https://github.com/Aditia-Nugraha/Smiling-Mask-Only/blob/7543286de1c97a1bda023a01bfe38ead3ce160b5/Screenshot%202026-04-01%20073630.png)

## 👥 Team

**Nova Games**

Global Game Jam 2026

---

## 📜 License

This project was created as part of **Global Game Jam 2026** and is intended for learning, experimentation, and portfolio purposes.
