using System;

namespace MyApp
{
    public enum PokemonType
    {
        Normal, Fire, Water, Grass, 
        Electric, Ice, Fighting, Poison, 
        Ground, Flying, Psychic, Bug, 
        Rock, Ghost, Dragon, Dark, 
        Steel, Fairy
    }

    interface IPokemon
    {
        string MonsterName { get; set; }
        string Type_1 { get; set; }
        string? Type_2 { get; set; }

        int Current_Health { get; set; }
        int Atk_Stage { get; set; }
        int SpAtk_Stage { get; set; }
        int Def_Stage { get; set; }
        int SpDef_Stage { get; set; }
        int Spe_Stage { get; set; }

        int Max_HP { get; set; }
        int Atk { get; set; }
        int SpAtk { get; set; }
        int Def { get; set; }
        int SpDef { get; set; }
        int Spe { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}