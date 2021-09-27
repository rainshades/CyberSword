using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera VirtualCamera;
    [SerializeField]
    LayerMask InteractionLayers;
    BattleSpots BattleSpots;

    private void Awake()
    {
        BattleSpots = GetComponent<BattleSpots>(); 
    }

    private void FixedUpdate()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, 1.0f, InteractionLayers);

        if (col.Length > 0)
        {
            VirtualCamera.gameObject.SetActive(true);
            GetComponent<PlayerMovement>().InBattle = true;
            BattleSpots.LaunchBattle(col[0].transform.gameObject);
            col[0].transform.gameObject.SetActive(false); 
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1.0f);
    }
}
