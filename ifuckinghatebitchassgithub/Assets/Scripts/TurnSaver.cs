using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSaver : MonoBehaviour
{
    public GameObject SmoothTurn;
    public GameObject SnapTurn;
    public bool IsSmooth;
    public bool IsSnap;

    private void Start()
    {
        IsSmooth = PlayerPrefs.GetInt("Smooth") == 1 ? true : false;
        IsSnap = PlayerPrefs.GetInt("Snap") == 1 ? true : false;
        if (IsSmooth)
        {
            SmoothTurn.SetActive(true);
            Debug.Log("SmoothTurnEnabled");
        }
        else
        {
            if (IsSnap)
            {
                SnapTurn.SetActive(true);
                Debug.Log("SnapTurnEnabled");
            }
            else
            {
                Debug.Log("NoTurnEnabled");
            }
        }
    }
    void Update()
    {
        if (SmoothTurn.active == true)
        {
            bool val = true;
            PlayerPrefs.SetInt("Smooth", val ? 1 : 0);
            PlayerPrefs.Save();

        }
        else
        {
            bool val = false;
            PlayerPrefs.SetInt("Smooth", val ? 1 : 0);
            PlayerPrefs.Save();
        }
        if(SnapTurn.active == true)
        {
            bool val = true;
            PlayerPrefs.SetInt("Snap", val ? 1 : 0);
            PlayerPrefs.Save();
        }
        else
        {
            bool val = false;
            PlayerPrefs.SetInt("Snap", val ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
