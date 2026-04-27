using System;

namespace BattleSimulator;

public enum StatusCondition
{
    None, Rest, Burn, Paralyze, Sleep, Poison, Freeze
}
    
public static class StatusHandler
{
    private static Random _random = new Random();

    // Burn + Poison delar samma logik
    public static void ApplyEndOfTurn(Pokemon pokemon)
    {
        if(pokemon.BattleState.Status == StatusCondition.Burn || pokemon.BattleState.Status == StatusCondition.Poison)
        {
            int damage = pokemon.BattleState.Status == StatusCondition.Burn
                ? pokemon.MaxHP / 16
                : pokemon.MaxHP / 8;

            pokemon.BattleState.CurrentHealth -= damage;
            Console.WriteLine($"{pokemon.Name} is hurt by {pokemon.BattleState.Status}! {damage} damage!");
        }
    }

    // Sleep + Freeze
    public static bool CanAttack(Pokemon pokemon)
    {
        if(pokemon.BattleState.Status == StatusCondition.Sleep || 
           pokemon.BattleState.Status == StatusCondition.Freeze)
        {
            bool wakeUp = pokemon.BattleState.Status == StatusCondition.Sleep
                // Sleep.
                ? --pokemon.BattleState.SleepTurns <= 0
                // Freeze logic 20% chance to unfreeze.
                : _random.Next(0, 5) == 0;

            if(wakeUp)
            {
                string message = pokemon.BattleState.Status == StatusCondition.Sleep
                    ? "woke up!" : "thawed out!";
                pokemon.BattleState.Status = StatusCondition.None;
                Console.WriteLine($"{pokemon.Name} {message}");
            }
            else
            {
                string message = pokemon.BattleState.Status == StatusCondition.Sleep
                    ? "is fast asleep!" : "is frozen solid!";
                Console.WriteLine($"{pokemon.Name} {message}");
                return false;
            }
        }

        // Paralysis 1/4 chance of paralysis skipping a turn.
        if(pokemon.BattleState.Status == StatusCondition.Paralyze)
        {
            if(_random.Next(0, 4) == 0)
            {
                Console.WriteLine($"{pokemon.Name} is paralyzed! It can't move!");
                return false;
            }
        }

        return true;
    }

    // Stat changes for different status conditions e.g Burn, Paralysis.
    public static int GetAtkStat(Pokemon attacker, int attackStat)
    {
        if(attacker.BattleState.Status == StatusCondition.Burn)
            return attackStat / 2;
        return attackStat;
    }

    public static int GetSpeStat(Pokemon pokemon, int speStat)
    {
        if(pokemon.BattleState.Status == StatusCondition.Paralyze)
            return speStat / 2;
        return speStat;
    }
}