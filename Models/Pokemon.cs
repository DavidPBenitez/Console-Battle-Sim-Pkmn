using System;

namespace BattleSimulator;

public class Pokemon : IPokemon
{
    // Name + typing
    public string Name { get; set; }
    public PokemonType Type1 { get; set; }
    public PokemonType? Type2 { get; set; }

    public Move[] Moves { get; set; } = new Move[4];

    // Base stats:
    public int MaxHP { get; set; }
    public int Atk { get; set; }
    public int SpAtk { get; set; }
    public int Def { get; set; }
    public int SpDef { get; set; }
    public int Spe { get; set; }

    // in combat stats:
    public BattleStats BattleState { get; set; } = new BattleStats();

    public Pokemon(string name, PokemonType type1, PokemonType? type2, Move[] moves, int maxHP, int atk, int def, int spAtk, int spDef, int spe)
    {
        Name = name;
        Type1 = type1;
        Type2 = type2;

        MaxHP = maxHP;
        Atk = atk;
        Def = def;
        SpAtk = spAtk;
        SpDef = spDef;
        Spe = spe;

        Moves = moves;

        BattleState.CurrentHealth = maxHP;
    }
}