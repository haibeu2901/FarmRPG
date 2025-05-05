using FarmRPG.GameLogic;

namespace FarmRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your farmer name: ");
            string farmerName = Console.ReadLine(); 
            Game game = new Game(farmerName);
            game.Run();
        }
    }
}
