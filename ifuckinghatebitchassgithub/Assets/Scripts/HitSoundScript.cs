using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.VR;

public class HitSoundScript : MonoBehaviour
{
    public bool Dirt;
    public bool Glass;
    public bool Grass;
    public bool Metal;
    public bool Snow;
    public bool Stone;
    public bool Wood;
    private PhotonVRManager MyManager;
    void OnTriggerEnter(Collider other)
    {
        GameObject obj = GameObject.FindGameObjectWithTag("PhotonVRManager");
        MyManager = obj.GetComponent<PhotonVRManager>();
        PhotonVRManager reader = MyManager;
        if (other.gameObject.name == "LeftHand Controller")
        {
            if (Dirt)
            {
                reader.LocalPlayer.LeftDirt.Play();
            }
            if (Glass)
            {
                reader.LocalPlayer.LeftGlass.Play();
            }
            if (Grass)
            {
                reader.LocalPlayer.LeftGrass.Play();
            }
            if (Metal)
            {
                reader.LocalPlayer.LeftMetal.Play();
            }
            if (Snow)
            {
                reader.LocalPlayer.LeftSnow.Play();
            }
            if (Stone)
            {
                reader.LocalPlayer.LeftStone.Play();
            }
            if (Wood)
            {
                reader.LocalPlayer.LeftWood.Play();
            }
        }
        if (other.gameObject.name == "RightHand Controller")
        {
            if (Dirt)
            {
                reader.LocalPlayer.RightDirt.Play();
            }
            if (Glass)
            {
                reader.LocalPlayer.RightGlass.Play();
            }
            if (Grass)
            {
                reader.LocalPlayer.RightGrass.Play();
            }
            if (Metal)
            {
                reader.LocalPlayer.RightMetal.Play();
            }
            if (Snow)
            {
                reader.LocalPlayer.RightSnow.Play();
            }
            if (Stone)
            {
                reader.LocalPlayer.RightStone.Play();
            }
            if (Wood)
            {
                reader.LocalPlayer.RightWood.Play();
            }
        }
    }
}