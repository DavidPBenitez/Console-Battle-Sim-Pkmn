using System;

namespace BattleSimulator
{
    public class BattleLoop
    {
        Pokemon _player;
        Pokemon _opponent;

        public BattleLoop(Pokemon player, Pokemon opponent)
        {
            _player = player;
            _opponent = opponent;
        }

        public void BeginBattle()
        {
            while(_player.BattleState.IsAlive && _opponent.BattleState.IsAlive)
            {
                PlayerTurn();
                OpponentTurn();
            }        
        }
        private void PlayerTurn()
        {
            for(int i = 0; i < _player.Moves.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {_player.Moves[i].MoveName}");
            }
        }
        private void OpponentTurn() { }
    }
}