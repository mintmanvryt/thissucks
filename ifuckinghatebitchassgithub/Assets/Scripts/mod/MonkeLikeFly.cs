using UnityEngine;
using easyInputs;

public class MonkeLikeFly : MonoBehaviour
{
    [Header("script made by The Kachow DO NOT STEAL")]
    [Header("Give credits to The Kachow")]
    private string scriptCredit = "Script made by @TheKachow. Do not change or distribute without proper credit.";

    public Rigidbody GorillaPlayer;
    public float forwardForce = 30.0f; // force applied when going forward
    public float backwardForce = 30.0f; // force applied when going backward
    public Transform FlyDirection; // the transform where the force is applied from

    void Update()
    {
        if (EasyInputs.GetTriggerButtonDown(EasyHand.RightHand))
        {
            GorillaPlayer.AddForceAtPosition(FlyDirection.forward.normalized * forwardForce, FlyDirection.position, ForceMode.Acceleration);
        }
        else if (EasyInputs.GetTriggerButtonDown(EasyHand.LeftHand))
        {
            GorillaPlayer.AddForceAtPosition(-FlyDirection.forward.normalized * backwardForce, FlyDirection.position, ForceMode.Acceleration);
        }
    }
}
