using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmRPG.Data;
using FarmRPG.Entities;

namespace FarmRPG.GameLogic
{
    public class Action
    {
        private readonly Farmer _farmer;

        public Action( Farmer farmer )
        {
            _farmer = farmer;
        }

        public void checkFarmStatus()
        {
            Console.WriteLine("\n--- Farm Status ---");
            Console.WriteLine($"Money: ${_farmer.money}");

            Console.WriteLine("Crops:");
            if (_farmer.Crops.Any() )
            {
                foreach (var crop in _farmer.Crops)
                {
                    Console.WriteLine($"- {crop.Type} (Growth Stage: {crop.GrowthStage})");
                }
            }
            else
            {
                Console.WriteLine("No crops planted.");
            }

            Console.WriteLine("Animals:");
            if (_farmer.Animals.Any() )
            {
                foreach (var animal in _farmer.Animals)
                {
                    Console.WriteLine($"- {animal.Name} ({animal.Type}, Hunger: {animal.Hunger})");
                }
            }
            else
            {
                Console.WriteLine("No animals on the farm.");
            }

            Console.WriteLine("-------------------\n");
        }

        public void PlantCrop()
        {
            Console.WriteLine("Available crops to plant:");
            for (int i = 0; i < Items.CropTypes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Items.CropTypes[i]} (Cost: $10)");
            }

            Console.Write("Enter the number of the crop you want to plant (or 0 to cancel): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Items.CropTypes.Length)
            {
                if (_farmer.spendMoney(10))
                {
                    _farmer.addCrop(new Crop(Items.CropTypes[choice - 1]));
                }
            }
            else if (choice != 0)
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        public void HarvestCrops()
        {
            if (_farmer.Crops.Any(c => c.isMature()))
            {
                Console.WriteLine("Ready to harvest crops:");
                List<Crop> harvestedCrops = new List<Crop>();
                foreach (var crop in _farmer.Crops.Where(c => c.isMature()).ToList())
                {
                    Console.WriteLine($"- {crop.Type}");
                    crop.harvest();
                    _farmer.earnMoney(20); // Earn $20 for each harvested crop
                    harvestedCrops.Add(crop);
                }
                foreach (var cropToRemove in harvestedCrops)
                {
                    _farmer.Crops.Remove(cropToRemove); // Remove harvested crops
                }
            }
            else
            {
                Console.WriteLine("No crops are ready to harvest.");
            }
        }

        public void BuyAnimal()
        {
            Console.WriteLine("Available animals to buy:");
            for (int i = 0; i < Items.AnimalTypes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Items.AnimalTypes[i]} (Cost: $30)");
            }

            Console.Write("Enter the number of the animal you want to buy (or 0 to cancel): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Items.AnimalTypes.Length)
            {
                if (_farmer.spendMoney(30))
                {
                    Console.Write($"Enter a name for your new {Items.AnimalTypes[choice - 1]}: ");
                    string name = Console.ReadLine() ?? "Unnamed";
                    _farmer.addAnimal(new Animal(name, Items.AnimalTypes[choice - 1]));
                }
            }
            else if (choice != 0)
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        public void FeedAnimals()
        {
            if (_farmer.Animals.Any())
            {
                Console.WriteLine("Which animal do you want to feed?");
                for (int i = 0; i < _farmer.Animals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_farmer.Animals[i].Name} ({_farmer.Animals[i].Type})");
                }
                Console.Write("Enter the number of the animal to feed (or 0 to cancel): ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _farmer.Animals.Count)
                {
                    _farmer.Animals[choice - 1].feed();
                }
                else if (choice != 0)
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            else
            {
                Console.WriteLine("You have no animals to feed.");
            }
        }

        public void AdvanceDay()
        {
            Console.WriteLine("\n--- A new day dawns on the farm ---");
            foreach (var crop in _farmer.Crops)
            {
                crop.grow();
            }
            foreach (var animal in _farmer.Animals)
            {
                animal.update();
            }
            Console.WriteLine("------------------------------------\n");
        }
    }
}
