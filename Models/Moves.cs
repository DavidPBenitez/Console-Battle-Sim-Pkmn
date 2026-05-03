using System;

namespace BattleSimulator;

public enum MoveCategory
{
    Physical, Special, Status
}

public static class EffectChance
{
    public static Random Instance { get; } = new Random();
}
// Delegate for self targeting moves such as Rest.
public delegate void MoveSelfTarget(Pokemon user);

// Delegate type that defines a method in which a pokemon will receive an effect.
public delegate void MoveExtraEffect(Pokemon target);

public class Move
{
    // Properties of a move.
    public string MoveName { get; set; }
    public PokemonType Type { get; set; }
    public MoveCategory Category { get; set; }
    public int? BaseDamage { get; set; }
    public int? Accuracy { get; set; }

    // Holds an effect that triggers when move gets used an is also nullable.
    public MoveExtraEffect? OnHitEffectChance { get; set; } = null;
    public MoveSelfTarget? OnSelfEffect { get; set; } = null;

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
