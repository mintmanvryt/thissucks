using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(PhotonView))]
public class PhotonAudioSourceView : MonoBehaviourPun, IPunObservable
{
    private AudioSource Audio;
    private PhotonView PhotonV;
    private bool Playing;

    private void Awake()
    {
        Audio = gameObject.GetComponent<AudioSource>();
        Audio.playOnAwake = false;
        PhotonV = gameObject.GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (Audio.isPlaying)
        {
            if (Playing == false)
            {
                Playing = true;
                PhotonV.RPC("Play", RpcTarget.AllBufferedViaServer);
            }
        }
        else
        {
            Playing = false;
        }
    }

    [PunRPC]
    public void Play()
    {
        if (!PhotonV.IsMine)
        {
            Audio.Play();
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Playing);
        }
        else if (stream.IsReading)
        {
            Playing = (bool)stream.ReceiveNext();
        }
    }
}
