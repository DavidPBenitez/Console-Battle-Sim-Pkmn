using System;

namespace BattleSimulator;

public static class PokemonData
{
    public static Pokemon Charizard = new Pokemon
    (
        "Charizard", 
        PokemonType.Fire, 
        PokemonType.Flying, 
        new Move[]
        {
            MoveData.Flamethrower,
            MoveData.AirSlash,
            MoveData.Protect,
            MoveData.HeatWave
        },
        153, //HP
        104, //Attack
        98, //Defense
        129, //Sp. Attack
        105, //Sp. Defense
        120 // Speed
    );
    public static Pokemon Venusaur = new Pokemon
    (
        "Venasaur", 
        PokemonType.Grass, 
        PokemonType.Poison, 
        new Move[]
        {
            MoveData.EnergyBall,
            MoveData.SludgeBomb,
            MoveData.Protect,
            MoveData.GigaDrain
        },
        155, //HP
        102, //Attack
        103, //Defense
        120, //Sp. Attack
        120, //Sp. Defense
        100 // Speed
    );
    public static Pokemon Golem = new Pokemon
    (
        "Golem", 
        PokemonType.Rock, 
        PokemonType.Ground, 
        new Move[]
        {
            MoveData.Earthquake,
            MoveData.RockSlide,
            MoveData.FirePunch,
            MoveData.ThunderPunch
        },
        155, //HP
        140, //Attack
        150, //Defense
        75, //Sp. Attack
        85, //Sp. Defense
        65 // Speed
    );
    public static Pokemon Rhydon = new Pokemon
    (
        "Rhydon", 
        PokemonType.Ground, 
        PokemonType.Rock, 
        new Move[]
        {
            MoveData.BodySlam,
            MoveData.RockTomb,
            MoveData.Blizzard,
            MoveData.HammerArm
        },
        180, //HP
        150, //Attack
        140, //Defense
        45, //Sp. Attack
        45, //Sp. Defense
        40 // Speed
    );
    public static Pokemon Snorlax = new Pokemon
    (
        "Snorlax", 
        PokemonType.Normal,
        null,  
        new Move[]
        {
            MoveData.Rest,
            MoveData.Lick,
            MoveData.BodySlam,
            MoveData.DoubleEdge
        },
        235, //HP
        130, //Attack
        85, //Defense
        85, //Sp. Attack
        130, //Sp. Defense
        50 // Speed
    );
    public static Pokemon PunchingBag = new Pokemon
    (
        "Dummy", 
        PokemonType.Normal,
        null,  
        new Move[]
        {
            MoveData.Splash,
            MoveData.Splash,
            MoveData.Splash,
            MoveData.Splash
        },
        10000, //HP
        1, //Attack
        100, //Defense
        1, //Sp. Attack
        100, //Sp. Defense
        1 // Speed
    );
    public static Pokemon Blastoise = new Pokemon
    (
        "Blastoise", 
        PokemonType.Water, 
        null, 
        new Move[]
        {
            MoveData.HydroPump,
            MoveData.Scald,
            MoveData.ShellSmash,
            MoveData.BodySlam
        },
        154, //HP
        83, //Attack
        100, //Defense
        85, //Sp. Attack
        105, //Sp. Defense
        78 // Speed
    );
}