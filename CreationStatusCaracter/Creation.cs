using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationStatusCaracter {
    public class Creation {
        private List<int> statsNumbers = new List<int>() { 15, 12, 10, 8 };
        private List<string> classesList = new List<string>() { "Warrior", "Mage", "Rogue" };
        public Status status = new Status();

        public void CreationCaracter()
        {
            InitFunction();

            Console.WriteLine("Lets choose your atributtes...");
            Console.Write("Choose the points of atribbuttes between: ");
            Console.WriteLine(string.Join(", ", statsNumbers));

            DistributeStatus();

            RandomHP();

            Console.WriteLine("Your caracter is created!");
        }

        private void InitFunction()
        {
            Console.WriteLine("----------- Welcome to my RPG made in C# -----------");
            Console.WriteLine("Let's make create your character in a RPG");
            Console.WriteLine("Your name: ");
            status.Name = Console.ReadLine();
            do
            {
                Console.WriteLine("Your class: ");
                status.Class = Console.ReadLine();
            } while (!classesList.Contains(status.Class));
            
            classesList.Remove(status.Class);
            
            Console.WriteLine("Your age: ");
            Console.WriteLine("Your age must be more than 16 years old.");
            status.Age = int.Parse(Console.ReadLine());
        }

        private void DistributeStatus()
        {
            do
            {
                Console.Write("Strength: ");
                status.Strength = int.Parse(Console.ReadLine());
            } while (!statsNumbers.Contains(status.Strength));

            statsNumbers.Remove(status.Strength);

            do
            {
                Console.Write("Dexterity: ");
                status.Dex = int.Parse(Console.ReadLine());
            } while (!statsNumbers.Contains(status.Dex));

            statsNumbers.Remove(status.Dex);

            do
            {
                Console.Write("Intelligence: ");
                status.Intelligence = int.Parse(Console.ReadLine());
            } while (!statsNumbers.Contains(status.Intelligence));

            do
            {
                Console.Write("Charisma: ");
                status.Charisma = int.Parse(Console.ReadLine());
            } while (!statsNumbers.Contains(status.Charisma));
        }

        private void RandomHP() {
            Console.WriteLine("Now is time to roll your constitution... Press enter to roll the dice...");
            var pressEnter = Console.ReadLine();

            while (!string.IsNullOrEmpty(pressEnter))
            {
                Console.WriteLine("Now is time to roll your constitution... Press enter to roll the dice...");
                pressEnter = Console.ReadLine();
            }

            Random rnd = new Random();
            status.Constitution = rnd.Next(8, 15);
            Console.WriteLine("Your constitution is: {0}", status.Constitution);
        }
    }
}
