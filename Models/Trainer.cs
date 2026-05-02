using System;

namespace BattleSimulator;

public class Trainer
{
    public string TrainerName { get; set; }
    public Pokemon[] Team { get; set; }
    public int ActiveIndex { get; set; }
    public Pokemon ActivePokemon => Team[ActiveIndex];
    public Trainer(string trainerName, Pokemon[] team)
    {
        TrainerName = trainerName;
        Team = team;
        ActiveIndex = 0;
    }
    public bool HasAlivePokemon()
    {
        foreach(Pokemon pokemon in Team)
        {
            if(pokemon.BattleState.IsAlive)
            {
                return true;
            }
        }
        return false;
    }
    public Pokemon NextAlivePokemon()
    {
        foreach(Pokemon pokemon in Team)
        {
            if(pokemon.BattleState.IsAlive && pokemon != ActivePokemon)
            {
                return pokemon;
            }
        }
        return null;
    }

    public void SendNextPokemon()
    {
        for(int i = 0; i < Team.Length; i++)
        {
            if(Team[i] == NextAlivePokemon())
            {
                ActiveIndex = i;
                Console.WriteLine($"Go! {ActivePokemon.Name}!");
                return;
            }
        }
    }
    
    public void SwitchPokemon(int index)
    {
        if(index >= 0 && index < Team.Length && Team[index].BattleState.IsAlive)
        {
            ActiveIndex = index;
        }
    }
}      