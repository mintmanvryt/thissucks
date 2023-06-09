using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDisable : MonoBehaviour
{
       [Header("SCRIPT MAKE BY VILLAN DONT STEAL IT")]
    public int coinAmount = 10;
    public Transform leftHand;
    public Transform rightHand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HandTag" && (other.transform == leftHand || other.transform == rightHand))
        {
            int currentCoins = PlayerPrefs.GetInt("coins");
            PlayerPrefs.SetInt("coins", currentCoins - coinAmount);
        }
    }
}
