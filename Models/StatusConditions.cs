using System;

namespace BattleSimulator;

public enum StatusCondition
{
    None, Rest, Burn, Paralyze, Sleep, Poison, Freeze, Flinch
}
    
public static class StatusHandler
{
    private static Random _random = new Random();

    // Health reducing status conditions e.g Burn and Poison.
    public static void ApplyEndOfTurn(Pokemon pokemon)
    {
        if(pokemon.BattleState.Status == StatusCondition.Burn || pokemon.BattleState.Status == StatusCondition.Poison)
        {
            int damage;
            string message;
            if(pokemon.BattleState.Status == StatusCondition.Burn)
            {
                damage = pokemon.MaxHP / 16;
                message = $"{pokemon.Name} is hurt by its burn! 🔥 {damage} damage!";
            }
            else
            {
                damage = pokemon.MaxHP / 8;
                message = $"{pokemon.Name} is hurt by poison! ☠️ {damage} damage!";
            }
            pokemon.BattleState.CurrentHealth -= damage;
            Console.WriteLine(message);
        }
    }

    // Turn skipping conditions.
    public static bool TurnSkip(Pokemon pokemon)
    {
        // Flinch check
        if(pokemon.BattleState.IsFlinched)
        {
            pokemon.BattleState.IsFlinched = false;
            Console.WriteLine($"{pokemon.Name} flinched!");
            return false;
        }

        // Sleep + Freeze check
        if(pokemon.BattleState.Status == StatusCondition.Sleep || pokemon.BattleState.Status == StatusCondition.Freeze)
        {
            bool wakeUp;

            if(pokemon.BattleState.Status == StatusCondition.Sleep)
                wakeUp = --pokemon.BattleState.SleepTurns <= 0;
            else
                wakeUp = _random.Next(0, 5) == 0;

            if(wakeUp)
            {
                string message;
                if(pokemon.BattleState.Status == StatusCondition.Sleep)
                    message = "woke up!";
                else
                    message = "thawed out!";

                pokemon.BattleState.Status = StatusCondition.None;
                Console.WriteLine($"{pokemon.Name} {message}");
            }
            else
            {
                string message;
                if(pokemon.BattleState.Status == StatusCondition.Sleep)
                    message = "is fast asleep! 💤";
                else
                    message = "is frozen solid! ❄";

                Console.WriteLine($"{pokemon.Name} {message}");
                return false;
            }
        }

        // Paralysis — 1/4 chance of skipping a turn
        if(pokemon.BattleState.Status == StatusCondition.Paralyze)
        {
            if(_random.Next(0, 4) == 0)
            {
                Console.WriteLine($"{pokemon.Name} is paralyzed! It can't move! ⚡");
                return false;
            }
        }

        return true;
    }

    // Burn causes attack stat to be halved.
    public static int GetAtkStat(Pokemon attacker, int attackStat)
    {
        if(attacker.BattleState.Status == StatusCondition.Burn)
            return attackStat / 2;
        return attackStat;
    }

    // Paralysis causes speed stat to be halved.
    public static int GetSpeStat(Pokemon pokemon, int speStat)
    {
        if(pokemon.BattleState.Status == StatusCondition.Paralyze)
            return speStat / 2;
        return speStat;
    }
}