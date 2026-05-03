using System;

namespace BattleSimulator;
class Program
{
    static void Main(string[] args)
    {
        Trainer player = new Trainer("You", new Pokemon[] { PokemonData.Blastoise });
        Trainer opponent = new Trainer("Gym Leader Brock", new Pokemon[] { PokemonData.PunchingBag });
        
        BattleLoop battle = new BattleLoop(player, opponent);
        battle.BeginBattle();
    }

}