using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.VR;
using easyInputs;

public class UFOPickup : MonoBehaviour
{
    [Header("SCRIPT MADE BY RATEIX. DONT STEAL OR YOU'RE A NERD. AND CONSEQUENCES WILL HAPPEN. IF YOU DO NOT GIVE CREDIT FOR A VIDEO ON THIS, A  STRIKE WILL BE PLACED. BY USING THIS SCRIPT YOU ARE ACCEPTING THAT YOU WILL NOT CLAIM THIS AS YOURS AND IF YOU DO, YOU WILL GET A STRIKE.")]
    public PhotonView PhotonView;
    public GameObject collider;
    public Transform actualUFO;
    public Transform bigfatmonkey;
    public bool Abducting;


    void Start()
    {
        if (PhotonView.IsMine)
        {
            collider.SetActive(false);
        }

     bigfatmonkey = GameObject.Find("GorillaPlayer").GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider other)
    {
        Abducting = true;
    }
    void Update()
    {
if (Abducting)
        {
            bigfatmonkey.position = actualUFO.position;
            
            
        }
        }
    }
