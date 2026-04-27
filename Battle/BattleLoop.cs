using System;

namespace BattleSimulator;

public class BattleLoop
{
    Trainer _player;
    Trainer _opponent;
    public BattleLoop(Trainer player, Trainer opponent)
    {
        _player = player;
        _opponent = opponent;
    }
    public void BeginBattle()
    {
        while(_player.HasAlivePokemon() && _opponent.HasAlivePokemon())
        {
            // speed determines which pokemon gets to go first.
            if(_player.ActivePokemon.Spe >= _opponent.ActivePokemon.Spe)
            {
                PlayerTurn();
                OpponentTurn();
            }
            else
            {
                OpponentTurn();
                PlayerTurn();
            }
        }        
    }
    private void PlayerTurn()
    {
        BattleDisplay.ShowBattleStatus(_player.ActivePokemon, _opponent.ActivePokemon);
        BattleDisplay.ShowMoves(_player.ActivePokemon);
    
        Console.WriteLine("Choose move! [ 1 - 4 ]");
        string input = Console.ReadLine();
        Move selectedMove = null;
    
        if(int.TryParse(input, out int choice) && choice >= 1 && choice <= 4)
        {
            selectedMove = _player.ActivePokemon.Moves[choice - 1];
        }
        else 
        { 
            Console.WriteLine("Invalid input! [ 1 - 4 ].");
            return;
        }
    
        AccuracyCheck accuracyCheck = new AccuracyCheck();
        if(accuracyCheck.IsHit(selectedMove))
        {
            DamageCalc damageCalc = new DamageCalc();
            int damage = damageCalc.CalculateDamage(_player.ActivePokemon, _opponent.ActivePokemon, selectedMove);
            _opponent.ActivePokemon.BattleState.CurrentHealth -= damage;
            Console.WriteLine($"{_player.ActivePokemon.Name} used {selectedMove.MoveName}! {damage} damage!");
        }
        else
        {
            Console.WriteLine($"{_player.ActivePokemon.Name}'s attack missed!");
        }
    }
    private void OpponentTurn()
    {
        Opponent npc = new Opponent();
        Move selectedMove = npc.BestMove(_opponent.ActivePokemon, _player.ActivePokemon);
    }
}