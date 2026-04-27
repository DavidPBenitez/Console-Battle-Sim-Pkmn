using System;

namespace BattleSimulator;

public enum MoveCategory
{
    Physical, Special, Status
}
public class Move
{
    // Properties of a move.
    public string MoveName { get; set; }
    public PokemonType Type { get; set; }
    public MoveCategory Category { get; set; }
    public int? BaseDamage { get; set; }
    public int? Accuracy { get; set; }
    // For moves that raise or lower a Pokemons stats gets sent to BattleStats.cs
    public int? AtkChange { get; set; } = null;
    public int? DefChange { get; set; } = null;
    public int? SpAtkChange { get; set; } = null;
    public int? SpDefChange { get; set; } = null;
    public int? SpeedChange { get; set; } = null;
    // constructor for our moves.
    public Move(string moveName, PokemonType type, MoveCategory category, int? baseDamage=null, int? accuracy=null)
    {
        MoveName = moveName;
        Type = type;
        Category = category;
        BaseDamage = baseDamage;
        Accuracy = accuracy;
    }
}
