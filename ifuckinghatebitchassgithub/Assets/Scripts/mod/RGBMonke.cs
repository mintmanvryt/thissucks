using UnityEngine;
using System.Collections;
using Photon.VR;

public class RGBMonke : MonoBehaviour {
    public float speed = 1.0f;

    void Update () {
        Color color = Color.HSVToRGB(Mathf.Repeat(Time.time * speed, 1f), 1f, 1f);
        PhotonVRManager.SetColour(color);
    }
}
