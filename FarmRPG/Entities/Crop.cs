using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmRPG.Entities
{
    public class Crop
    {
        public string Type { get; private set; }
        public int GrowthStage { get; private set; } // 0: Seeded, 1: Growing, 2: Mature

        public Crop(string type)
        {
            Type = type;
            GrowthStage = 0;
        }

        public void grow()
        {
            if (GrowthStage < 2)
            {
                GrowthStage++;
                if (GrowthStage == 2)
                {
                    Console.WriteLine($"{Type} is now mature and ready to harvest!");
                }
            }
        }

        public bool isMature()
        {
            return GrowthStage == 2;
        }

        public void harvest()
        {
            Console.WriteLine($"Harvested {Type}");
            GrowthStage = 0; // Reset growth stage after harvesting
        }
    }
}
