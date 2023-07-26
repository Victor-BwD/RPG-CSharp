using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinarRPG.src.Entities
{
    public static class TurnManager
    {
        private static bool _playerTurn;
        private static bool _monsterTurn;

        public static void SetPlayerTurn()
        {
            _playerTurn = true;
            _monsterTurn = false;
        }

        public static void SetMonsterTurn()
        {
            _playerTurn = false;
            _monsterTurn = true;
        }

        public static bool IsPlayerTurn()
        {
            return _playerTurn;
        }

        public static bool IsMonsterTurn()
        {
            return _monsterTurn;
        }
    }
}
