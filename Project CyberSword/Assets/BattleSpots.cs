using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSpots : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerBattlePoint;

    [SerializeField]
    GameObject[] EnemyBattlePoints; 

    public void LaunchBattle(GameObject go)
    {
        transform.position = PlayerBattlePoint.transform.position;
        List<Vector3> positions = new List<Vector3>(); 
        foreach(GameObject go2 in EnemyBattlePoints)
        {
            positions.Add(go2.transform.position); 
        }
        go.GetComponent<EnemyParty>().SummonEnemies(positions);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(PlayerBattlePoint.transform.position, Vector3.one / 4 );
        foreach (GameObject EnemyBattlePoint in EnemyBattlePoints)
        {
            Gizmos.DrawWireCube(EnemyBattlePoint.transform.position, Vector3.one / 4);
        }
    }
}
