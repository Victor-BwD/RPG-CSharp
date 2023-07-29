using GameRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinarRPG.Entities;

namespace TreinarRPG.src.Entities
{
    internal class CombatManager<T> where T : Monster
    {
        private PlayerCharacter _playerCharacter;
        private List<Monster> _monsters;
        private IJob _currentJob;
        private bool _fightRunning = true; // Variável para controlar o estado do jogo
        private int turnNumber;

        public CombatManager(PlayerCharacter playerCharacter, List<Monster> monsters, IJob currentJob)
        {
            _playerCharacter = playerCharacter;
            _monsters = monsters;
            _currentJob = currentJob;
        }

        public void StartCombat()
        {
            _playerCharacter.SetHp();
            var iniciative = _currentJob.Iniciative;
            
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

            while (_fightRunning)
            {
                Console.WriteLine("Player turn...");
                Console.WriteLine();

                var selectedMonsterIndex = SelectedMonsterIndex();

                if (_playerCharacter.JobName == "Wizard")
                {
                    var mage = (Mage)_currentJob;
                    Console.WriteLine("Choose your spell to cast: ");

                    foreach (var spell in mage.Spells)
                    {
                        Console.WriteLine($"[{mage.Spells.IndexOf(spell) + 1}] {spell.Name}");
                    }
                    
                    Monster selectedMonster = _monsters[selectedMonsterIndex];
                    mage.CastSpell("Fireball", selectedMonster);
                    Console.WriteLine(selectedMonster.HealthPoints);
                }

                if (selectedMonsterIndex >= 0 && selectedMonsterIndex < _monsters.Count)
                {
                    Monster selectedMonster = _monsters[selectedMonsterIndex];
                    _currentJob.Attack(selectedMonster);
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
                    _fightRunning = false;
                }
            }
        }

        private int SelectedMonsterIndex()
        {
            foreach (var monster in _monsters)
            {
                Console.WriteLine($"[{_monsters.IndexOf(monster) + 1}] {monster.Name} (HP: {monster.HealthPoints})");
            }

            Console.Write("Choose the goblin to attack: ");
            int selectedMonsterIndex = int.Parse(Console.ReadLine()) - 1;
            return selectedMonsterIndex;
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
                _fightRunning = false;
            }

            TurnManager.SetPlayerTurn();
            PlayerTurn();
        }

        

    }
}
