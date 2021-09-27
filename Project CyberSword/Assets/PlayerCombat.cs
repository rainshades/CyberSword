using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : CombatEntity
{
    public void AttackEnemy()
    {
        BattleManager.instance.NextTurn(); 
    }//Basic attack

    public void Defend()
    {
        BattleManager.instance.NextTurn();
    }//Doubles defence

    public void OpenBag()
    {
        BattleManager.instance.NextTurn();
    }//Opens the bag menu to use items 

    public void Speak()
    {
        BattleManager.instance.NextTurn(); 
    }//Speaking is magic? A gamble that can either pacify, injur, enrage, buff opponents?

    protected override void OnDefeat()
    {
        //GameOver
    }
}
