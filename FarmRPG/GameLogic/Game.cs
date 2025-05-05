using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmRPG.Entities;

namespace FarmRPG.GameLogic
{
    public class Game
    {
        private readonly Farmer _farmer;
        private readonly Action _action;
        private bool _isRunning;

        public Game(string farmerName)
        {
            _farmer = new Farmer(farmerName);
            _action = new Action(_farmer);
            _isRunning = true;
        }

        public void Run()
        {
            Console.WriteLine($"Welcome to the Farmer RPG, {_farmer.Name}!");

            while (_isRunning)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine() ?? "";

                switch (choice.ToLower())
                {
                    case "1":
                        _action.checkFarmStatus();
                        break;
                    case "2":
                        _action.PlantCrop();
                        break;
                    case "3":
                        _action.HarvestCrops();
                        break;
                    case "4":
                        _action.BuyAnimal();
                        break;
                    case "5":
                        _action.FeedAnimals();
                        break;
                    case "6":
                        _action.AdvanceDay();
                        break;
                    case "7":
                        _isRunning = false;
                        Console.WriteLine("Thank you for playing!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Check Farm Status");
            Console.WriteLine("2. Plant Crop");
            Console.WriteLine("3. Harvest Crops");
            Console.WriteLine("4. Buy Animal");
            Console.WriteLine("5. Feed Animals");
            Console.WriteLine("6. Advance to the Next Day");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
        }
    }
}
