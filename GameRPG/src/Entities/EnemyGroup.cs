using GameRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinarRPG
{
    public record EnemyGroup
    {
        public List<Monster> Monsters { get; set; }

        public EnemyGroup(List<Monster> monsters)
        {
            Monsters = monsters;
        }
    }
}
