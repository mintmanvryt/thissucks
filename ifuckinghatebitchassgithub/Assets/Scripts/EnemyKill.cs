using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill: MonoBehaviour
{
    public GameObject GorillaPlayer;

    public GameObject RespawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GorillaPlayer.transform.position = RespawnPoint.transform.position;
        }
        if (other.gameObject.CompareTag("MainCamera"))
        {
            GorillaPlayer.transform.position = RespawnPoint.transform.position;
        }
    }
}