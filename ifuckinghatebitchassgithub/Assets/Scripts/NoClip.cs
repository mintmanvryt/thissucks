using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;

public class NoClip : MonoBehaviour
{
    public CapsuleCollider capsule;
    public Collider cam;
    // Start is called before the first frame update
    void Start()
    {
        capsule.GetComponent<CapsuleCollider>();
        cam.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EasyInputs.GetGripButtonDown(EasyHand.RightHand))
        {
            capsule.isTrigger = true;
            cam.isTrigger = true;
        }
    }
}
