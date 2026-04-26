using System;

namespace BattleSimulator
{
    public class BattleStats
    {
    public int CurrentHealth { get; set; }
    public int AtkStage { get; set; }
    public int SpAtkStage { get; set; }
    public int DefStage { get; set; }
    public int SpDefStage { get; set; }
    public int SpeStage { get; set; }
    public bool IsAlive => CurrentHealth > 0;
    }
}