using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public TurnManager TurnManager;
    [SerializeField]
    Canvas BattleCanvs;
    public GameObject Current; 

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Current != null)
        {
            if (Current.CompareTag("Player"))
            {
                BattleCanvs.gameObject.SetActive(true);
            }
            else 
            {
                BattleCanvs.gameObject.SetActive(false);
                Current.GetComponent<EnemyCombat>().OnEnemyTurn();
                NextTurn();
            }
        }
    }

    public void NextTurn()
    {
        int index = TurnManager.TurnOrder.IndexOf(Current);
        if(index + 1 < TurnManager.TurnOrder.Count)
        {
            index++; 
            Current = TurnManager.TurnOrder[index];
        }
        else
        {
            Current = TurnManager.TurnOrder[0];
        }
    }
}
