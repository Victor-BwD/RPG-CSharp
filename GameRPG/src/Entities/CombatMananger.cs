using GameRPG;
using System;
using System.Collections.Generic;

namespace TreinarRPG.Entities
{
    internal class CombatManager<T> where T : Monster
    {
        private PlayerCharacter _playerCharacter;
        private List<Monster> _monsters;
        private IJob _currentJob;
        private bool _fightRunning = true; // Variável para controlar o estado do jogo

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
                PlayerTurn();
            }
            else
            {
                MonsterTurn();
            }
        }

        private void VerifyEnemyHP()
        {
            _monsters.RemoveAll(monster => monster.HealthPoints <= 0);
        }

        private bool IsEnemyListIsEmpty()
        {
            return _monsters.Count == 0;
        }

        private void PlayerTurn()
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

                if (!IsEnemyListIsEmpty())
                {
                    MonsterTurn();
                }
            }

            bool allMonsterDefeated = _monsters.TrueForAll(m => m.HealthPoints <= 0);
            if (allMonsterDefeated)
            {
                _fightRunning = false;
            }
        }

        private int SelectedMonsterIndex()
        {
            for (int i = 0; i < _monsters.Count; i++)
            {
                var monster = _monsters[i];
                Console.WriteLine($"[{i + 1}] {monster.Name} (HP: {monster.HealthPoints})");
            }

            Console.Write("Choose the goblin to attack: ");
            int selectedMonsterIndex;
            while (!int.TryParse(Console.ReadLine(), out selectedMonsterIndex) || selectedMonsterIndex < 1 || selectedMonsterIndex > _monsters.Count)
            {
                Console.Write("Invalid input. Choose the monster to attack: ");
            }

            return selectedMonsterIndex - 1;
        }

        private void MonsterTurn()
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

            PlayerTurn();
        }
    }
}
