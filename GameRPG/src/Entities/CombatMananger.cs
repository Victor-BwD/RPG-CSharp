using GameRPG;
using TreinarRPG.src.Entities;

namespace TreinarRPG.Entities
{
    internal class CombatManager<T> where T : Monster
    {
        private readonly PlayerCharacter _playerCharacter;
        private readonly List<Monster> _monsters;
        private readonly IJob _currentJob;

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
                ExecuteMageSpellSelectionAndCast(selectedMonsterIndex);
            }
            else
            {
                if (selectedMonsterIndex >= 0 && selectedMonsterIndex < _monsters.Count)
                {
                    Monster selectedMonster = _monsters[selectedMonsterIndex];
                    _currentJob.Attack(selectedMonster);
                    Console.WriteLine(selectedMonster.HealthPoints);

                    PerformMonsterRound();
                }
            }
        }

        private void ExecuteMageSpellSelectionAndCast(int selectedMonsterIndex)
        {
            var mage = (Mage)_currentJob;
            Console.WriteLine("Choose your spell to cast: ");


            DisplayMageSpells(mage);

            int spellIndex;

            while (!int.TryParse(Console.ReadLine(), out spellIndex) || spellIndex < 0 ||
                   spellIndex > mage.Spells.Count)
            {
                Console.WriteLine("Invalid spell, choose a spell to attack: ");
            }

            spellIndex--;


            Monster selectedMonster = _monsters[selectedMonsterIndex];
            mage.CastSpell(mage.Spells[spellIndex].Name, selectedMonster);
            Console.WriteLine(selectedMonster.HealthPoints);

            PerformMonsterRound();
        }

        private static void DisplayMageSpells(Mage mage)
        {
            foreach (var spell in mage.Spells)
            {
                Console.WriteLine($"[{mage.Spells.IndexOf(spell) + 1}] {spell.Name}");
            }
        }

        private void PerformMonsterRound()
        {
            VerifyEnemyHP();

            if (!IsEnemyListIsEmpty())
            {
                MonsterTurn();
            }
            else
            {
                Console.WriteLine("You have defeated all the monsters!");
                var continueCampaign = new StartCampaign(_playerCharacter, _currentJob, new CampaignStory());
                continueCampaign.ContinueCampaign();
            }
        }

        private int SelectedMonsterIndex()
        {
            for (int i = 0; i < _monsters.Count; i++)
            {
                var monster = _monsters[i];
                Console.WriteLine($"[{i + 1}] {monster.Name} (HP: {monster.HealthPoints})");
            }

            Console.Write("Choose the monster to attack: ");
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
                return;
            }

            PlayerTurn();
        }
    }
}
