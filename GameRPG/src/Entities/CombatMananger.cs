using GameRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinarRPG.src.Entities
{
    internal class CombatManager<T> where T : Monster
    {
        private PlayerCharacter _playerCharacter;
        private List<T> _monsters;
        private IJob _job;
        private bool fightRunning = true; // Variável para controlar o estado do jogo

        public CombatManager(PlayerCharacter playerCharacter, List<T> monsters, IJob job)
        {
            _playerCharacter = playerCharacter;
            _monsters = monsters;
            _job = job;
        }

        public void StartCombate()
        {
            _playerCharacter.SetHp();
            var iniciative = _job.Iniciative;
            
            Console.WriteLine($"{_monsters.Count} goblins appears!");
            Console.WriteLine();

            if (iniciative > _monsters[0].Iniciative)
            {
                TurnManager.SetPlayerTurn();
                
                PlayerTurn();


            }
            else
            {
                TurnManager.SetMonsterTurn();
                MonsterTurn();
            }
        }

        private void VerifyEnemyHP()
        {
            foreach (var monster in _monsters)
            {
                if (monster.HealthPoints <= 0)
                {
                    _monsters.Remove(monster);
                    break;
                }
            }
        }

        private bool IsEnemyListIsEmpty()
        {
            if (_monsters.Count <= 0) return true;

            return false;
        }

        private void PlayerTurn()
        {
            TurnManager.SetPlayerTurn();
            bool fightRunning = true;

            while (fightRunning)
            {
                Console.WriteLine("Player turn...");
                Console.WriteLine();

                for (int i = 0; i < _monsters.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {_monsters[i].Name} (HP: {_monsters[i].HealthPoints})");
                }

                Console.Write("Choose the goblin to attack: ");
                int selectedMonsterIndex = int.Parse(Console.ReadLine()) - 1;

                if (selectedMonsterIndex >= 0 && selectedMonsterIndex < _monsters.Count)
                {
                    Monster selectedMonster = _monsters[selectedMonsterIndex];
                    _job.Attack(selectedMonster);
                    Console.WriteLine(selectedMonster.HealthPoints);

                    VerifyEnemyHP();
                    TurnManager.SetMonsterTurn();

                    if (!IsEnemyListIsEmpty() && TurnManager.IsMonsterTurn())
                    {
                        MonsterTurn();
                    }
                }

                bool allMonsterDefeated = _monsters.All(m => m.HealthPoints <= 0);
                if (allMonsterDefeated)
                {
                    fightRunning = false;
                }
            }
        }

        void MonsterTurn()
        {
            Console.WriteLine("Monster turn...");
            Console.WriteLine();

            

            foreach (Monster monster in _monsters)
            {
                monster.Attack(_playerCharacter);
                Console.WriteLine($"Player life: {_playerCharacter.ActualHp}");
            }

            if (_playerCharacter.ActualHp <= 0)
            {
                Console.WriteLine("You have been defeated.");
                fightRunning = false;
            }

            TurnManager.SetPlayerTurn();
            PlayerTurn();
        }


    }
}
