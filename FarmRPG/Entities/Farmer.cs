using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmRPG.Entities
{
    public class Farmer
    {
        public string Name { get; private set; }
        public int money { get; private set; }
        public List<Crop> Crops { get; private set; }
        public List<Animal> Animals { get; private set; }

        public Farmer(string name)
        {
            Name = name;
            money = 10000;
            Crops = new List<Crop>();
            Animals = new List<Animal>();
        }

        public void addCrop(Crop crop)
        {
            Crops.Add(crop);
            Console.WriteLine($"{Name} planted a {crop.Type}");
        }

        public void addAnimal(Animal animal)
        {
            Animals.Add(animal);
            Console.WriteLine($"{Name} got a new {animal.Type} named {animal.Name}");
        }

        public void earnMoney(int amount)
        {
            money += amount;
            Console.WriteLine($"{Name} earned ${amount}. Current money: ${money}");
        }

        public bool spendMoney(int amount)
        {
            if (money >= amount)
            {
                money -= amount;
                Console.WriteLine($"{Name} spent ${amount}. Current Money: ${money}");
                return true;
            } 
             Console.WriteLine($"{Name} doesn't have enough money");
             return false;
        }
    }
}
