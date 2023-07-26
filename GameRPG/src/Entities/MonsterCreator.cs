using GameRPG;

namespace TreinarRPG.Entities;

public class MonsterCreator
{
    public List<Monster> CreateMonster(List<Monster> monstersToCreate)
    {
        List<Monster> monsters = new List<Monster>();

        foreach (Monster monster in monstersToCreate)
        {
            monsters.Add(monster);
        }

        return monsters;
    }
}