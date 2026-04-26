using System;

namespace BattleSimulator
{
    public enum MoveCategory
    {
        Physical, Special, Status, Protect
    }

    public class Move
    {
        public string MoveName { get; set; }
        public PokemonType Type { get; set; }
        public MoveCategory Category { get; set; }
        public int? BaseDamage { get; set; }
        public int? Accuracy { get; set; }

        public Move(string moveName, PokemonType type, MoveCategory category, int? baseDamage=null, int? accuracy=null)
        {
            MoveName = moveName;
            Type = type;
            Category = category;
            BaseDamage = baseDamage;
            Accuracy = accuracy;
        }
    }
}