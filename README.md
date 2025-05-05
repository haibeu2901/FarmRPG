# Simple Farmer RPG in .NET 8

This is a very basic console RPG game where you play as a farmer managing their daily tasks. It's designed as a learning exercise for .NET 8 and object-oriented programming principles in C#.

## Getting Started

1.  Make sure you have .NET 8 SDK installed on your machine.
2.  Clone or create this project structure.
3.  Navigate to the `FarmerRPG` directory in your terminal.
4.  Run the game using the command: `dotnet run`

## Game Overview

The game simulates a day in the life of a farmer. You will be able to perform actions such as:

* Checking your farm status (money, crops, animals).
* Planting new crops.
* Harvesting mature crops.
* Feeding your animals.

The game is turn-based, with each action representing a part of the day.

## File Structure

* `Data/`: Contains static data for items in the game.
* `Entities/`: Holds the classes representing the core entities like the farmer, animals, and crops.
* `GameLogic/`: Contains the logic for game actions and the main game flow.
* `Program.cs`: The entry point of the application.
* `README.md`: This file.

## Learning Objectives

This project aims to help you understand:

* Basic .NET 8 console application structure.
* Object-oriented programming concepts (classes, objects, encapsulation, etc.).
* Separation of concerns in software design.

## Further Development

This is a very basic version. Potential future enhancements could include:

* More crop types and animal types.
* A more complex economic system.
* Weather effects.
* Saving and loading game state.
