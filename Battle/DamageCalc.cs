using System;

namespace BattleSimulator;

public class DamageCalc
{
    public int CalculateDamage(Pokemon attackingPkmn, Pokemon defendingPkmn, Move move)
    {
        int attackStat;
        int defenseStat;
        
        if(move.Category == MoveCategory.Physical)
        {

            attackStat = attackingPkmn.Atk;

            attackStat = StatChangeHandler.StatChangeApply(attackStat, attackingPkmn.BattleState.AtkStage); // stat drops

            if(attackingPkmn.BattleState.Status == StatusCondition.Burn) attackStat /= 2; // burn


            defenseStat = defendingPkmn.Def;
            defenseStat = StatChangeHandler.StatChangeApply(defenseStat, defendingPkmn.BattleState.DefStage);
        }
        else
        {
            attackStat = attackingPkmn.SpAtk;
            attackStat = StatChangeHandler.StatChangeApply(attackStat, attackingPkmn.BattleState.SpAtkStage); // stat drops


            defenseStat = defendingPkmn.SpDef;
            defenseStat = StatChangeHandler.StatChangeApply(defenseStat, defendingPkmn.BattleState.SpDefStage);

        }
        
        // (Same type attack bonus), triggers if e.g Charizard who is a Fire type uses a Fire Move!
        float stabMult = 1.0f;
        if(move.Type == attackingPkmn.Type1 || move.Type == attackingPkmn.Type2)
        {
            stabMult = 1.5f; // 50%  more damage.
        }
        float typeEffectiveness = TypeChart.GetEffectiveness(move.Type, defendingPkmn.Type1);
        // For 4x weaknesse and 0.25x resistance e.g Charizard ( Fire + Flying ) vs Rock type moves.
        if(defendingPkmn.Type2 != null)
        {
            typeEffectiveness *= TypeChart.GetEffectiveness(move.Type, defendingPkmn.Type2.Value);   
        }
        // Charizard using a STAB Flamethrower vs a normal type Pokemon: 90 * (129 / 120) * 1.5 / 2 = 72 total damage.
        // (e.g Fire vs Grass) 2x Effective damage: 145 * 2x = 290 total damage.
        // (e.g Fire vs Rock/Ground) 0.25x Resisted damage: 145 / 0.5x = 36.25 = 36 (Truncated due to integer behavior)
        int damage = (int)((move.BaseDamage ?? 0) * ((float)attackStat / defenseStat) * stabMult * typeEffectiveness / 2);
        return damage; 
    }
}