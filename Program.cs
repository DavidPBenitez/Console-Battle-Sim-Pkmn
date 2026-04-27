using System;

namespace BattleSimulator;
class Program
{
    static void Main(string[] args)
    {
        Trainer player = new Trainer("David", new Pokemon[] { PokemonData.Charizard, PokemonData.Charizard });
        Trainer opponent = new Trainer("Grass Trainer", new Pokemon[] { PokemonData.Venusaur });
        
        BattleLoop battle = new BattleLoop(player, opponent);
        battle.BeginBattle();
    }
    
}