using System;

namespace BattleSimulator;
class Program
{
    static void Main(string[] args)
    {
        Trainer player = new Trainer("You", new Pokemon[] { PokemonData.Charizard });
        Trainer opponent = new Trainer("Gym Leader Brock", new Pokemon[] { PokemonData.Venusaur, PokemonData.Snorlax });
        
        BattleLoop battle = new BattleLoop(player, opponent);
        battle.BeginBattle();
    }

}