using System;

namespace PkmnAbilitySection
{
    public abstract class Ability
    {
        public string AbilityName { get; set; }
        public string AbilityDescription { get; set; }

        public abstract void Activate();

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{AbilityName}: {AbilityDescription}");
        }     
    }

    public abstract class EntryAbility : Ability
    {
        
    } 
}

