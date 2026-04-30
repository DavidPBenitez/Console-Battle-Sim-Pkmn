using System;

namespace BattleSimulator;

public static class MoveData
{
    // Status moves
    public static Move Protect = new Move("Protect", PokemonType.Normal, MoveCategory.Status);
    public static Move Rest = new Move("Rest", PokemonType.Psychic, MoveCategory.Status);

    // Normal moves
    public static Move BodySlam = new Move("Body Slam", PokemonType.Normal, MoveCategory.Physical, 85, 100)
    {
        OnHitEffectChance = target => 
        {
            // 30% chance of inflicting Paralysis.
            if(EffectChance.Instance.Next(0, 100) < 30)
            { target.BattleState.Status = StatusCondition.Paralyze; }
        }
    };
    public static Move DoubleEdge = new Move("Double Edge", PokemonType.Normal, MoveCategory.Physical, 120, 100);

    // Fire moves
    public static Move Flamethrower = new Move("Flamethrower", PokemonType.Fire, MoveCategory.Special, 80, 100)
    {
        OnHitEffectChance = target => 
        {
            if(EffectChance.Instance.Next(0, 100) < 10)
            { target.BattleState.Status = StatusCondition.Burn; }
        }
    };
    public static Move HeatWave = new Move("Heat Wave", PokemonType.Fire, MoveCategory.Special, 95, 90)
    {
        OnHitEffectChance = target => 
        {
            if(EffectChance.Instance.Next(0, 100) < 10)
            { target.BattleState.Status = StatusCondition.Burn; }
        }
    };
    public static Move FirePunch = new Move("Fire Punch", PokemonType.Fire, MoveCategory.Physical, 75, 100)
    {
        OnHitEffectChance = target => 
        {
            if(EffectChance.Instance.Next(0, 100) < 10)
            { target.BattleState.Status = StatusCondition.Burn; }
        }
    };

    // Water Moves
    public static Move HydroPump = new Move("Hydro Pump", PokemonType.Water, MoveCategory.Special, 110, 80);
    public static Move Surf = new Move("Surf", PokemonType.Water, MoveCategory.Special, 90, 100);
    public static Move Scald = new Move("Scald", PokemonType.Water, MoveCategory.Special, 80, 100)
    {
        OnHitEffectChance = target => 
        {
            if(EffectChance.Instance.Next(0, 100) < 30)
            { target.BattleState.Status = StatusCondition.Burn; }
        }
    };

    // Grass moves
    public static Move GigaDrain = new Move("Giga Drain", PokemonType.Grass, MoveCategory.Special, 75, 100);
    public static Move EnergyBall = new Move("Energy Ball", PokemonType.Grass, MoveCategory.Special, 90, 100)
    {
        OnHitEffectChance = target => 
        {
            // 10% chance to lower Special Defense by 1 stage.
            if(EffectChance.Instance.Next(0, 100) < 10)
            { target.BattleState.SpDefStage -= 1; }
        }
    };

    //Electric moves
    public static Move ThunderPunch = new Move("Thunder Punch", PokemonType.Grass, MoveCategory.Physical, 75, 100);

    // Flying moves
    public static Move AirSlash = new Move("Air Slash", PokemonType.Flying, MoveCategory.Special, 75, 95)
    {
        OnHitEffectChance = target => 
        {
            if(EffectChance.Instance.Next(0, 100) < 30)
            { target.BattleState.Status = StatusCondition.Flinch; }
        }
    };

    // Poison moves
    public static Move SludgeBomb = new Move("Sludge Bomb", PokemonType.Poison, MoveCategory.Special, 90, 100)
    {
        OnHitEffectChance = target => 
        {
            if(EffectChance.Instance.Next(0, 100) < 30)
            { target.BattleState.Status = StatusCondition.Poison; }
        }
    };

    // Psychic moves
    public static Move Psychic = new Move("Psychic", PokemonType.Psychic, MoveCategory.Special, 90, 100)
    {
        OnHitEffectChance = target => 
        {
            // 10% chance to lower Special Defense by 1 stage.
            if(EffectChance.Instance.Next(0, 100) < 10)
            { target.BattleState.SpDefStage -= 1; }
        }
    };

    //Ground moves
    public static Move Earthquake = new Move("Earthquake", PokemonType.Ground, MoveCategory.Physical, 100, 100);

    //Rock moves
    public static Move RockSlide = new Move("Rock Slide", PokemonType.Rock, MoveCategory.Physical, 75, 90);
    public static Move RockTomb = new Move("Rock Tomb", PokemonType.Rock, MoveCategory.Physical, 60, 95);

    // Ice Moves
    public static Move Blizzard = new Move("Blizzard", PokemonType.Ice, MoveCategory.Special, 110, 70)
    {
        OnHitEffectChance = target => 
        {
            if(EffectChance.Instance.Next(0, 100) < 10)
            { target.BattleState.Status = StatusCondition.Freeze; }
        }
    };

    // Fighting moves
    public static Move HammerArm = new Move("Hammer Arm", PokemonType.Fighting, MoveCategory.Physical, 100, 90);

    // Ghost moves
    public static Move Lick = new Move("Lick", PokemonType.Ghost, MoveCategory.Physical, 30, 100)
    {
        OnHitEffectChance = target => 
        {
            if(EffectChance.Instance.Next(0, 100) < 30)
            { target.BattleState.Status = StatusCondition.Paralyze; }
        }
    };
    
}