using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTint : MonoBehaviour
{
[Header("THIS SCRIPT WAS MADE BY TORREN. IT IS NOT YOURS. DO NOT DISTRIBUTE WITHOUT PERMISSION.")]
    [Header("Put ther player camera here")]
    public Camera playerCamera;
    [Header("Set this to the color that you want when entering.")]
    public Color color2 = Color.blue;
    [Header("Set this to the color that you want when exiting. White Recomended")]
    public Color color3 = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponent<Camera>();
        playerCamera.clearFlags = CameraClearFlags.SolidColor;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        playerCamera.backgroundColor = color2;
    }
    private void OnTriggerExit(Collider other)
    {
        playerCamera.backgroundColor = color3;
    }
}
