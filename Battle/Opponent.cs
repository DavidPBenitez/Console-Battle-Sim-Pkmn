using System;

namespace BattleSimulator;

public class Opponent
{
    private Random _random = new Random();
    
    public Move BestMove(Pokemon opponent, Pokemon player)
    {
        Move bestMove = null;
        int bestDamage = -1;
        DamageCalc damageCalc = new DamageCalc();

        foreach(Move move in opponent.Moves)
        {
            if(move.BaseDamage == null) continue;
            int damage = damageCalc.CalculateDamage(opponent, player, move);
            if(damage > bestDamage)
            {
                bestDamage = damage;
                bestMove = move;
            }
        }
        return bestMove ?? opponent.Moves[_random.Next(0, 4)];
    }
}