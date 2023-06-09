using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;

public class checkpoint : MonoBehaviour
{
    public Transform Checkpoint;
    public EasyHand MoveHand;
    public Transform hand;
public EasyHand TeleportHand;
public Transform gorilla;

    void Update()
    {
        if (EasyInputs.GetTriggerButtonDown(MoveHand))
        {
            Checkpoint.position = hand.position;
        }

        if (EasyInputs.GetTriggerButtonDown(TeleportHand))
        {
            gorilla.position = Checkpoint.position;
        }
    }
}
