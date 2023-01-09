using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationStatusCaracter {
    public class Creation {
        private readonly List<int> _statsNumbers = new () { 15, 12, 10, 8 };
        private readonly Status _status = new();
        

        

        public PlayerCharacter CreationCharacter()
        {
            InitFunction(out var name, out var job);

            Console.WriteLine("Lets choose your atributtes...");
            Console.Write("Choose the points of atribbuttes between: ");
            Console.WriteLine(string.Join(", ", _statsNumbers));

            DistributeStatus();

            ClassChoosed(job);

            Console.WriteLine("Your character is created!");
            return new PlayerCharacter(name, job, _status);
        }

        private void InitFunction(out string name, out Job job)
        {
            Console.WriteLine("----------- Welcome to my RPG made in C# -----------");
            Console.WriteLine("Let's make create your character in a RPG");
            Console.WriteLine("Your name: ");
            name = Console.ReadLine();
            
            do
            {
                Console.WriteLine("Your job: ");
                job = Job.Create(Console.ReadLine());
            } while (ReferenceEquals(job, null));
        }

        private void DistributeStatus()
        {
            do
            {
                Console.Write("Strength: ");
                _status.Strength = int.Parse(Console.ReadLine());
            } while (!_statsNumbers.Contains(_status.Strength));

            _statsNumbers.Remove(_status.Strength);

            do
            {
                Console.Write("Dexterity: ");
                _status.Dex = int.Parse(Console.ReadLine());
            } while (!_statsNumbers.Contains(_status.Dex));

            _statsNumbers.Remove(_status.Dex);

            do
            {
                Console.Write("Intelligence: ");
                _status.Intelligence = int.Parse(Console.ReadLine());
            } while (!_statsNumbers.Contains(_status.Intelligence));

            do
            {
                Console.Write("Charisma: ");
                _status.Charisma = int.Parse(Console.ReadLine());
            } while (!_statsNumbers.Contains(_status.Charisma));
        }

        // private void RandomHP() {
        //     Console.WriteLine("Now is time to roll your constitution... Press enter to roll the dice...");
        //     var pressEnter = Console.ReadLine();
        //
        //     while (!string.IsNullOrEmpty(pressEnter))
        //     {
        //         Console.WriteLine("Now is time to roll your constitution... Press enter to roll the dice...");
        //         pressEnter = Console.ReadLine();
        //     }
        //
        //     Console.WriteLine();
        //     
        //
        //     // Random rnd = new Random();
        //     //
        //     // if (_status.Class == "Warrior" || _status.Class == "warrior")
        //     // {
        //     //     _status.Constitution = rnd.Next(8, 15);
        //     // }else if (_status.Class == "Mage" || _status.Class == "mage")
        //     // {
        //     //     _status.Constitution = rnd.Next(4, 8);
        //     // }
        //     // else
        //     // {
        //     //     _status.Constitution = rnd.Next(6, 11);
        //     // }
        //     
        //     Console.WriteLine("Your constitution is: {0}", _status.Constitution);
        //     
        //     ClassChoosed();
        // }

        private void ClassChoosed(Job job)
        {
            Console.WriteLine($"You are a {job.JobName}");
            Console.WriteLine($"Your atributtes are {_status.Strength} in strength, {_status.Dex} in dexterity, {_status.Intelligence} in intelligence," +
                              $"{_status.Charisma} in charisma.");
        }
    }
}
