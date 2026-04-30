using System;

namespace BattleSimulator;

public class AccuracyCheck
{
    private Random randomRoll = new Random();
    public bool MoveHitsEnemy(Move move)
    {
        if(move.Accuracy == null) return true;
        int AccuracyRoll = randomRoll.Next(1, 101);
        return AccuracyRoll <= move.Accuracy;
    }
}
