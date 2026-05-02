using System;

namespace BattleSimulator;

public class BattleLoop
{
    Trainer _player;
    Trainer _opponent;
    Opponent _npc = new Opponent();
    AccuracyCheck _accuracyCheck = new AccuracyCheck();
    DamageCalc _damageCalc = new DamageCalc();

    public BattleLoop(Trainer player, Trainer opponent)
    {
        _player = player;
        _opponent = opponent;
    }

    public void BeginBattle()
    {
        while(_player.HasAlivePokemon() && _opponent.HasAlivePokemon())
        {
            if(_player.ActivePokemon.Spe >= _opponent.ActivePokemon.Spe)
            {
                PlayerTurn();
                StatusHandler.ApplyEndOfTurn(_player.ActivePokemon);

                if(!_opponent.ActivePokemon.BattleState.IsAlive) continue; //

                OpponentTurn();
                StatusHandler.ApplyEndOfTurn(_opponent.ActivePokemon);
            }
            else
            {
                OpponentTurn();
                StatusHandler.ApplyEndOfTurn(_opponent.ActivePokemon);
                PlayerTurn();
                StatusHandler.ApplyEndOfTurn(_player.ActivePokemon);
            }
        }        
    }

    private void PlayerTurn()
    {
        if(!StatusHandler.TurnSkip(_player.ActivePokemon)) return;

        Console.Clear();
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

        if(_accuracyCheck.MoveHitsEnemy(selectedMove)) // Checks if the random instance rolled favorably based on the moves accuracy.
        {
            int damage = _damageCalc.CalculateDamage(_player.ActivePokemon, _opponent.ActivePokemon, selectedMove); // Calculates damage based on ATK/SPATK against DEF/SPDEF respectively
                                                                                                                    // + Type effectiveness multiplier ( 4.0f, 2.0f, 0.5f, 0.25f )

            _opponent.ActivePokemon.BattleState.CurrentHealth -= damage; // reduces the health of targeted pokemon.

            Console.WriteLine($"{_player.ActivePokemon.Name} used {selectedMove.MoveName}! {damage} damage!"); // Displays the action.

            selectedMove.OnHitEffectChance?.Invoke(_opponent.ActivePokemon); // If the move applied an effect this line triggers.
        }
        else
        {
            Console.WriteLine($"{_player.ActivePokemon.Name}'s attack missed!");
        }
    }

    private void OpponentTurn()
    {
        if(!StatusHandler.TurnSkip(_opponent.ActivePokemon)) return;

        Move selectedMove = _npc.AutoSelectBestMove(_opponent.ActivePokemon, _player.ActivePokemon); // selects the move that will deal the most amount of damage versus the players active pokemon.

        if(_accuracyCheck.MoveHitsEnemy(selectedMove))
        {
            int damage = _damageCalc.CalculateDamage(_opponent.ActivePokemon, _player.ActivePokemon, selectedMove);

            _player.ActivePokemon.BattleState.CurrentHealth -= damage;

            Console.Clear();
            BattleDisplay.ShowBattleStatus(_player.ActivePokemon, _opponent.ActivePokemon);

            Console.WriteLine($"{_opponent.ActivePokemon.Name} used {selectedMove.MoveName}! {damage} damage!");

            selectedMove.OnHitEffectChance?.Invoke(_player.ActivePokemon);
        }
        else
        {
            Console.WriteLine($"{_opponent.ActivePokemon.Name}'s attack missed!");
        }
    }
}