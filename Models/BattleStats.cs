using System;

namespace BattleSimulator;

public class BattleStats
{
    // Status conditions stored here during a battle.
    public StatusCondition Status { get; set; } = StatusCondition.None;
    public bool IsFlinched { get; set; } = false;
    public int SleepTurns { get; set; } = 0;

    // Limits stat changes to a maximum of +6 and minimum of -6.
    private int ClampStage(int value) => Math.Clamp(value, -6, 6);

    // Pokemons health during a battle.
    public int CurrentHealth { get; set; }
    public bool IsAlive => CurrentHealth > 0;
    
    // Stat changes are stored here.
    private int _atkStage;
    private int _defStage;
    private int _spAtkStage;
    private int _spDefStage;
    private int _speStage;
    public int AtkStage
    {
        get => _atkStage;
        set => _atkStage = ClampStage(value);
    }
    public int DefStage
    {
        get => _defStage;
        set => _defStage = ClampStage(value);
    }
    public int SpAtkStage
    {
        get => _spAtkStage;
        set => _spAtkStage = ClampStage(value);
    }
    public int SpDefStage
    {
        get => _spDefStage;
        set => _spDefStage = ClampStage(value);
    }
    public int SpeedStage
    {
        get => _speStage;
        set => _speStage = ClampStage(value);
    }
}