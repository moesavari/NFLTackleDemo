# NFL Tackle Demo

## Project Overview
This project is a Unity demo designed to simulate a football scenario where a player attempts to score a touchdown while being pursued by 11 opposing players. The project demonstrates the following:
- Player control with keyboard inputs.
- Opponent AI that calculates pursuit angles and different speeds.
- Third-person camera view.
- Game mechanics to end the game when the player is tackled.

## Setup Instructions
1. Clone or Download the Repository:
   - Clone the repository or download the ZIP file and extract it.
2. Open the Project in Unity:
   - Open Unity Hub.
   - Click on "Add" and navigate to the extracted project folder.
   - Select the folder to open the project.
3. Play the Game:
   - Open the MainScene from the Assets/Scenes folder.
   - Click the Play button to start the game.

## Key Components
### Player Control
- Script: PlayerController.cs
- Description: This script allows the player to move using the WASD keys and rotate the camera with the mouse.

### Opponent AI
- Script: OpponentController.cs
- Description: This script controls the opponents' movement, calculating pursuit angles to follow the player. Each opponent has a random speed within a specified range.

### Game Controller
- Script: GameController.cs
- Description: Manages the overall game state, including tracking player movement and ending the game when a collision with an opponent occurs.

## How to Use
- Player Movement: Use W to move forward, A to move left, S to move backward, and D to move right.
- Camera Control: Move the mouse to rotate the camera.
- Game End: The game will end when an opponent collides with the player or when the player hits the opponent Touchdown collider, triggering the EndGame function.
