using System;

namespace BattleSimulator
{
    public static class MoveData
    {
        public static Move Protect = new Move("Protect", PokemonType.Normal, MoveCategory.Protect);
        public static Move Flamethrower = new Move("Flamethrower", PokemonType.Fire, MoveCategory.Special, 80, 100);
        public static Move AirSlash = new Move("Air Slash", PokemonType.Flying, MoveCategory.Special, 75, 95);
        public static Move HeatWave = new Move("Heat Wave", PokemonType.Fire, MoveCategory.Special, 95, 90);
        public static Move EnergyBall = new Move("Energy Ball", PokemonType.Grass, MoveCategory.Special, 90, 100);
        public static Move SludgeBomb = new Move("Sludge Bomb", PokemonType.Poison, MoveCategory.Special, 90, 100);
        public static Move GigaDrain = new Move("Energy Ball", PokemonType.Grass, MoveCategory.Special, 75, 100);


    }
}