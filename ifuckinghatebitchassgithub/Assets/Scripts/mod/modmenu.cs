using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;

public class modmenu : MonoBehaviour
{
    public EasyHand LeftHand;
    public GameObject ObjectToEnable;

    private void Update()
    {
        if (EasyInputs.GetSecondaryButtonDown(EasyHand.RightHand))
        {
            ObjectToEnable.SetActive(true);
        }
        else
        {
            ObjectToEnable.SetActive(false);
        }
    }
}