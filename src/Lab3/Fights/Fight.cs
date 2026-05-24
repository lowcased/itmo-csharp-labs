using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;

namespace Itmo.ObjectOrientedProgramming.Lab3.Fights;

public class Fight
{
    private readonly Table _table1;

    private readonly Table _table2;

    public Fight(Table table1, Table table2)
    {
        _table1 = table1.Clone();
        _table2 = table2.Clone();
    }

    public FightResult Start()
    {
        bool firstPlayerTurn = true;
        while (true)
        {
            ICreature? attackingCreature;
            ICreature? attackedCreature;
            if (firstPlayerTurn)
            {
                attackingCreature = _table1.GetAttacker();
                attackedCreature = _table2.GetAttacked();
            }
            else
            {
                attackingCreature = _table2.GetAttacker();
                attackedCreature = _table1.GetAttacked();
            }

            if (attackingCreature == null)
            {
                if (attackedCreature == null)
                {
                    return new FightResult.Draw();
                }

                firstPlayerTurn = !firstPlayerTurn;
                continue;
            }

            if (attackedCreature == null)
            {
                if (firstPlayerTurn)
                {
                    return new FightResult.FirstPlayerWon();
                }

                return new FightResult.SecondPlayerWon();
            }

            attackingCreature.Attack(attackedCreature);
            firstPlayerTurn = !firstPlayerTurn;
        }
    }
}