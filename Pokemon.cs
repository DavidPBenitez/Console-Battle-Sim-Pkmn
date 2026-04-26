using System;

namespace BattleSimulator;

public class Pokemon : IPokemon
{
    // IPokemon properties
    public string MonsterName { get; set; }
    public PokemonType Type1 { get; set; }
    public PokemonType? Type2 { get; set; }

    public int MaxHP { get; set; }
    public int Atk { get; set; }
    public int SpAtk { get; set; }
    public int Def { get; set; }
    public int SpDef { get; set; }
    public int Spe { get; set; }

    // Battle state
    public BattleStats BattleState { get; set; } = new BattleStats();

    // Konstruktor
    public Pokemon(string name, PokemonType type1, PokemonType? type2, int maxHP, int atk, int spAtk, int def, int spDef, int spe)
    {
        MonsterName = name;
        Type1 = type1;
        Type2 = type2;
        MaxHP = maxHP;
        Atk = atk;
        SpAtk = spAtk;
        Def = def;
        SpDef = spDef;
        Spe = spe;

        BattleState.CurrentHealth = maxHP;
    }
}