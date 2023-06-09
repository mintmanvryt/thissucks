using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VentOpenPro : MonoBehaviour
{
    [Header("VentOpenPro")]
    public UnityEvent OpenAnimation;
    public UnityEvent CloseAnimation;
    public string ModAcc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == ModAcc)
        {
            print("myEventTriggerOnEnter Activated. Triggering" + OpenAnimation);
            OpenAnimation.Invoke();
        }

        if (OpenAnimation == null)
        {
            print("myEventTriggerOnEnter was triggered but myEvents was null");
        }
      
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == ModAcc)
        {
            print("myEventTriggerOnEnter Activated. Triggering" + CloseAnimation);
            CloseAnimation.Invoke();
        }

        if (CloseAnimation == null)
        {
            print("myEventTriggerOnEnter was triggered but myEvents was null");
        }
    }
}