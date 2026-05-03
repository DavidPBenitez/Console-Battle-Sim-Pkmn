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
            if(StatChangeHandler.GetPokemonSpeedStat(_player.ActivePokemon) >= StatChangeHandler.GetPokemonSpeedStat(_opponent.ActivePokemon))
            {
                PlayerTurn();
                StatusHandler.ApplyEndOfTurn(_player.ActivePokemon);

                if(!_opponent.HasAlivePokemon()) continue;

                OpponentTurn();
                StatusHandler.ApplyEndOfTurn(_opponent.ActivePokemon);
            }
            else
            {
                OpponentTurn();
                StatusHandler.ApplyEndOfTurn(_opponent.ActivePokemon);

                if(!_player.HasAlivePokemon()) continue;

                PlayerTurn();  
                StatusHandler.ApplyEndOfTurn(_player.ActivePokemon);
            }
        }
        if(_player.HasAlivePokemon())
        {
            Console.WriteLine("You Won! 🥳");
        }
        else
        {
            Console.WriteLine("You lost! 🤕");  
        }
        Console.ReadKey();        
    }

    private void PlayerTurn()
    {
        if(!StatusHandler.TurnSkip(_player.ActivePokemon)) return;
    
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
    
        if(_accuracyCheck.MoveHitsEnemy(selectedMove) && selectedMove.BaseDamage != null)
        {
            int damage = _damageCalc.CalculateDamage(_player.ActivePokemon, _opponent.ActivePokemon, selectedMove);
            _opponent.ActivePokemon.BattleState.CurrentHealth -= damage;
            
            string moveMessage = selectedMove.Category switch
            {
                MoveCategory.Physical => $"{_player.ActivePokemon.Name} used {selectedMove.MoveName}! {damage} damage! 💥",
                MoveCategory.Special => $"{_player.ActivePokemon.Name} used {selectedMove.MoveName}! {damage} damage! ✨",
                _ => ""
            };
            Console.WriteLine(moveMessage);
            
            selectedMove.OnHitEffectChance?.Invoke(_opponent.ActivePokemon);
        }
        else if(selectedMove.Category == MoveCategory.Status)
        {
            Console.WriteLine($"{_player.ActivePokemon.Name} used {selectedMove.MoveName}!");
        }
        else
        {
            Console.WriteLine($"{_player.ActivePokemon.Name}'s attack missed!");
        }
    
        selectedMove.OnSelfEffect?.Invoke(_player.ActivePokemon);
    
        if(!_opponent.ActivePokemon.BattleState.IsAlive)
        {
            Console.WriteLine($"{_opponent.ActivePokemon.Name} fainted!");
            _opponent.SendNextPokemon();
            return;
        }
    }
    
    private void OpponentTurn()
    {
        if(!StatusHandler.TurnSkip(_opponent.ActivePokemon)) return;
    
        Move selectedMove = _npc.AutoSelectBestMove(_opponent.ActivePokemon, _player.ActivePokemon);
    
    if(_accuracyCheck.MoveHitsEnemy(selectedMove) && selectedMove.BaseDamage != null)
    {
        int damage = _damageCalc.CalculateDamage(_opponent.ActivePokemon, _player.ActivePokemon, selectedMove);
        _player.ActivePokemon.BattleState.CurrentHealth -= damage;
        
        string moveMessage = selectedMove.Category switch
        {
            MoveCategory.Physical => $"{_opponent.ActivePokemon.Name} used {selectedMove.MoveName}! {damage} damage! 💥",
            MoveCategory.Special => $"{_opponent.ActivePokemon.Name} used {selectedMove.MoveName}! {damage} damage! ✨",
            _ => ""
        };
        Console.WriteLine(moveMessage);
        
        selectedMove.OnHitEffectChance?.Invoke(_player.ActivePokemon);
    }
    else if(selectedMove.Category == MoveCategory.Status)
    {
        Console.WriteLine($"{_opponent.ActivePokemon.Name} used {selectedMove.MoveName}!");
    }
    else
    {
        Console.WriteLine($"{_opponent.ActivePokemon.Name}'s attack missed!");
    }
    
        selectedMove.OnSelfEffect?.Invoke(_opponent.ActivePokemon);
    
        if(!_player.ActivePokemon.BattleState.IsAlive)
        {
            Console.WriteLine($"{_player.ActivePokemon.Name} fainted!");
            _player.SendNextPokemon();
            return;
        }
    }
}