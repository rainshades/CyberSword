using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyParty : MonoBehaviour
{
    [SerializeField]
    GameObject[] Enemies; 

    public void SummonEnemies(List<Vector3> Positions)
    {
        for(int i = 0; i < Enemies.Length; i++)
        {
            GameObject go = Instantiate(Enemies[i], Positions[i], Quaternion.identity);
            go.transform.LookAt(FindObjectOfType<PlayerCombat>().transform);
        }

        BattleManager.instance.TurnManager = new TurnManager(Enemies, FindObjectOfType<PlayerCombat>().gameObject);
    }
}

[System.Serializable]
public class TurnManager
{
    public List<GameObject> TurnOrder = new List<GameObject>(); 
    
    public TurnManager(GameObject[] enemies, GameObject Player)
    {
        foreach(GameObject go in enemies)
        {
            TurnOrder.Add(go);
        }
        TurnOrder.Add(Player);
        TurnOrder = TurnOrderCalc(TurnOrder);
        BattleManager.instance.Current = TurnOrder[0];
    }

    public List<GameObject> TurnOrderCalc(List<GameObject> Combatstuff)
    {        
        var newList = Combatstuff.OrderByDescending(go => go.GetComponent<CombatEntity>().Speed).ToList();
        return newList; 
    }
}
