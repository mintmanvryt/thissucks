using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyController : MonoBehaviourPunCallbacks
{
    [Header("THIS SCRIPT WAS MADE BY FLIMCYVR. IT IS NOT YOURS.")]
    [Header("Distributing This Script Will Lead To A Permanent Ban and MORE!")]
    [Header("If you make a video on this script")]
    [Header("credit me with my discord and youtube")]
    public float moveSpeed = 3f;
    public float chaseRange = 10f;
    public float stoppingDistance = 1f;
    public float timeToShowGameObject = 2f;
    public GameObject gameobjectToShowOnCollision;

    private Transform player;
    private Vector3 initialPosition;
    private bool isCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsMasterClient) {
            // Find the closest player within range
            float distanceToClosestPlayer = Mathf.Infinity;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject p in players)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, p.transform.position);
                if (distanceToPlayer < distanceToClosestPlayer)
                {
                    distanceToClosestPlayer = distanceToPlayer;
                    player = p.transform;
                }
            }

            // Move towards the player if within range
            if (distanceToClosestPlayer < chaseRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

                // Rotate towards the player
                Vector3 direction = player.position - transform.position;
                transform.rotation = Quaternion.LookRotation(direction);
            }
            else
            {
                // Return to initial position
                transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);

                // Rotate towards initial position
                Vector3 direction = initialPosition - transform.position;
                transform.rotation = Quaternion.LookRotation(direction);
            }

            // If the enemy collides with the player, enable the game object for a set amount of time
            if (isCollided)
            {
                gameobjectToShowOnCollision.SetActive(true);
                Invoke("HideGameObject", timeToShowGameObject);
                isCollided = false;
            }
        }
    }

    // When the enemy collides with the player
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PhotonNetwork.IsMasterClient) {
                // Set isCollided to true so that the game object is shown on the next Update() call
                isCollided = true;
            }
        }
    }

    // Helper function to hide the game object after a set amount of time
    void HideGameObject()
    {
        gameobjectToShowOnCollision.SetActive(false);
    }

    // Draw a gizmo to visualize the chase range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
