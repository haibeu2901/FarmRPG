using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmRPG.Entities
{
    public class Animal
    {
        public String Name { get; private set; }
        public String Type { get; private set; }
        public int Hunger { get; private set; }

        public Animal(string name, string type)
        {
            Name = name;
            Type = type;
            Hunger = 5; // Initial hunger level
        }

        public void feed()
        {
            Console.WriteLine($"{Name} the {Type} has been fed.");
            Hunger = 0;
        }

        public void update()
        {
            Hunger++;
            if (Hunger > 10)
            {
                Console.WriteLine($"{Name} the {Type} is very hungry");
            }
        }
    }
}
