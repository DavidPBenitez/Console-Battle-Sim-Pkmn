using System;

namespace BattleSimulator;

public static class BattleDisplay
{
    // Loops over a Pokemon objects moves and writes them out.
    public static void ShowMoves(Pokemon pokemon)
    {
        for(int i = 0; i < pokemon.Moves.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {pokemon.Moves[i].MoveName}");
        }
    }
    // Casts CurrentHealth as float in order to get a decimal value -
    // that determines what color block will be displayed.
    public static void ShowHealthBar(Pokemon pokemon)
    {
        float hpPercent = (float)pokemon.BattleState.CurrentHealth / pokemon.MaxHP;
        int filledBlocks = (int)(hpPercent * 10);
        string block = hpPercent switch
        {
            > 0.75f => "🟩",
            > 0.50f => "🟨",
            > 0.25f => "🟧",
            _    => "🟥"
        };
            string bar = string.Concat(Enumerable.Repeat(block, filledBlocks))
            + string.Concat(Enumerable.Repeat("◽", 10 - filledBlocks));
            Console.WriteLine($"{pokemon.Name}: {bar} {pokemon.BattleState.CurrentHealth}/{pokemon.MaxHP}");
        
    }
    public static void ShowBattleStatus(Pokemon player, Pokemon opponent)
    {
        ShowHealthBar(opponent);
        ShowHealthBar(player);
    }
}