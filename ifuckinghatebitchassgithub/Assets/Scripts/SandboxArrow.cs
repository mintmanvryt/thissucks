using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandboxArrow : MonoBehaviour
{
    public Sandbox sandbox;
    public bool goesForward = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTag"))
        {
            if (goesForward)
            {
                sandbox.currentIndex = (sandbox.currentIndex + 1) % sandbox.prefabs.Count;
            }
            else
            {
                sandbox.currentIndex = (sandbox.currentIndex - 1 + sandbox.prefabs.Count) % sandbox.prefabs.Count;
            }
            sandbox.DisplayItem();
        }
    }
}
