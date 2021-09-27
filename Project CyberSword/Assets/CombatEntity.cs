using UnityEngine;

public abstract class CombatEntity : MonoBehaviour
{
    public int level;
    public Stats BaseStats;
    public float CurrentHealth;
    public float MaxHealth => StatsCalc(level, BaseStats.health, 1.0f);
    public float Attack => StatsCalc(level, BaseStats.attack, 1.0f);
    public float Defense => StatsCalc(level, BaseStats.defense, 1.0f);
    public float Speed => StatsCalc(level, BaseStats.speed, 1.0f);

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    float StatsCalc(float level, float stat, float modifier)
    {
        return stat * level * modifier;
    }

    protected abstract void OnDefeat();
}
