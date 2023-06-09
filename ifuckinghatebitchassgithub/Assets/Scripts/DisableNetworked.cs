using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DisableNetworked : MonoBehaviourPunCallbacks
{
    [Header("Made by Synerity, keep credits or you will get sued when my game releases...")]
    public GameObject objectDisable;

    [PunRPC]
    void DisableObject()
    {
        objectDisable.SetActive(false);
    }

    public void OnTriggerEnter()
    {
        photonView.RPC("DisableObject", RpcTarget.AllBuffered);
    }

    public void OnTriggerExit()
    {
        photonView.RPC("DisableObject", RpcTarget.AllBuffered);
    }
}
