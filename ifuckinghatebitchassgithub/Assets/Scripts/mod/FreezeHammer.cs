using System.Collections;
using UnityEngine;
using Photon.Pun;

namespace FrezHammer

{
    public class FreezeHammer : MonoBehaviour
    {
        [Header("SCRIPT MADE BY RATEIX. DONT STEAL OR YOU'RE A NERD. BY USING THIS SCRIPT YOUR ACCEPTING THAT IF I ASK YOU TO TAKE DOWN YOUR VIDEO ON THIS SCRIPT, THEN YOU MUST TAKE IT DOWN, IF YOU CHANGE THE HEADER TO SAY YOU MADE IT, YOU WILL ALSO BE TAKEN DOWN.")]
        public PhotonView photonView;
        public GameObject collider;
        public float Time;

        void Start()
        {
            if (photonView.IsMine)
            {
                collider.SetActive(false);
                Debug.Log("should be able to not freeze yourself lol");
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "HandTag")
            {
                StartCoroutine(FrezCoroutine());
            }
        }

        IEnumerator FrezCoroutine()
        {
            {
                            GameObject.FindGameObjectWithTag("FreezeHammer").GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("player is frozen lol");
             yield return new WaitForSeconds(Time);
             GameObject.FindGameObjectWithTag("FreezeHammer").GetComponent<Rigidbody>().isKinematic = false;
             Debug.Log("player was unfrozen lol");
            }
        }
    }
}
