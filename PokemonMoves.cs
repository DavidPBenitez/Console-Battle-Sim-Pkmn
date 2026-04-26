using System;

namespace BattleSimulator
{
    public enum MoveCategory
    {
        Physical, Special, Status, Protect
    }

    public class Move
    {
        public string? MoveName { get; set; }
        public PokemonType type { get; set; }
        public MoveCategory category { get; set; }
        public int baseDamage { get; set; }
        public int accuracy { get; set; }
    }
}