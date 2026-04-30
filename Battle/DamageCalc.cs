using System;

namespace BattleSimulator;

public class DamageCalc
{
    public int CalculateDamage(Pokemon attacker, Pokemon defender, Move move)
    {
        int attackStat;
        int defenseStat;
        
        if(move.Category == MoveCategory.Physical)
        {
            attackStat = attacker.Atk;
            defenseStat = defender.Def;
        }
        else
        {
            attackStat = attacker.SpAtk;
            defenseStat = defender.SpDef;
        }
        
        // (Same type attack bonus), triggers if e.g Charizard who is a Fire type uses a Fire Move!
        float stabMult = 1.0f;
        if(move.Type == attacker.Type1 || move.Type == attacker.Type2)
        {
            stabMult = 1.5f; // 50%  more damage.
        }
        float typeEffectiveness = TypeChart.GetEffectiveness(move.Type, defender.Type1);
        // For 4x weaknesse and 0.25x resistance e.g Charizard ( Fire + Flying ) vs Rock type moves.
        if(defender.Type2 != null)
        {
            typeEffectiveness *= TypeChart.GetEffectiveness(move.Type, defender.Type2.Value);   
        }
        // Charizard using a STAB Flamethrower vs a normal type Pokemon: 90 * (129 / 120) * 1.5 = 145 total damage.
        // (e.g Fire vs Grass) 2x Effective damage: 145 * 2x = 290 total damage.
        // (e.g Fire vs Rock/Ground) 0.25x Resisted damage: 145 / 0.5x = 36.25 = 36 (Truncated due to integer behavior)
        int damage = (int)((move.BaseDamage ?? 0) * ((float)attackStat / defenseStat) * stabMult * typeEffectiveness);
        return damage; 
    }
}
