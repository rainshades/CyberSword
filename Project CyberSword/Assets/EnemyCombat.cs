using System;
using UnityEngine;

public abstract class EnemyCombat : CombatEntity
{
    public abstract void OnEnemyTurn();

    public virtual void Swing()
    {
        PlayerCombat p = FindObjectOfType<PlayerCombat>();
        p.CurrentHealth -= Attack - Mathf.Floor(Defense * 0.25f);
    }
}
