using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnableNetworked : MonoBehaviourPunCallbacks
{
    [Header("Made by Synerity, keep credits or you will get sued when my game releases...")]
    public GameObject objectEnable;

    [PunRPC]
    void EnableObject()
    {
        objectEnable.SetActive(true);
    }

    public void OnTriggerEnter()
    {
        photonView.RPC("EnableObject", RpcTarget.AllBuffered);
    }
	
	public void OnTriggerExit()
    {
        photonView.RPC("EnableObject", RpcTarget.AllBuffered);
    }
}
