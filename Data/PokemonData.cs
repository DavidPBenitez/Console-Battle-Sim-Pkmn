using System;

namespace BattleSimulator
{
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

        public static Pokemon Venasaur = new Pokemon
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
    }

}