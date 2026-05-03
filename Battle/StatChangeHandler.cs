using System;

namespace BattleSimulator;
public static class StatChangeHandler
{
    private static readonly float[] stageMultipliers = { 2/8f, 2/7f, 2/6f, 2/5f, 2/4f, 2/3f, 2/2f, 3/2f, 4/2f, 5/2f, 6/2f, 7/2f, 8/2f };

    public static int GetPokemonSpeedStat(Pokemon pokemon)
    {
        int speed = pokemon.Spe;
        if(pokemon.BattleState.Status == StatusCondition.Paralyze) speed /= 2;
        return speed;
    }
    public static int StatChangeApply(int stat, int stage)
    {
        // Multiplies / divides stats
        return (int)(stat * stageMultipliers[stage + 6]);
    }
}