using System;

namespace BattleSimulator
{
    public interface IPokemon
    {
    string MonsterName { get; set; }
    PokemonType Type1 { get; set; }
    PokemonType? Type2 { get; set; }

    int MaxHP { get; set; }
    int Atk { get; set; }
    int SpAtk { get; set; }
    int Def { get; set; }
    int SpDef { get; set; }
    int Spe { get; set; }

    }
}