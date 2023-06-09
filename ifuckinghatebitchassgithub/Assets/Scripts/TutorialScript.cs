using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public Transform spawnLocation;

    public GameObject[] objectsToDisable;

    public float disableDuration = 5f;

    private const string spawnPositionKey = "SpawnPosition";

    public GameObject playerObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTag"))
        {
            PlayerPrefs.SetFloat(spawnPositionKey + "X", spawnLocation.position.x);
            PlayerPrefs.SetFloat(spawnPositionKey + "Y", spawnLocation.position.y);
            PlayerPrefs.SetFloat(spawnPositionKey + "Z", spawnLocation.position.z);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(spawnPositionKey + "X") &&
            PlayerPrefs.HasKey(spawnPositionKey + "Y") &&
            PlayerPrefs.HasKey(spawnPositionKey + "Z"))
        {
            float spawnX = PlayerPrefs.GetFloat(spawnPositionKey + "X");
            float spawnY = PlayerPrefs.GetFloat(spawnPositionKey + "Y");
            float spawnZ = PlayerPrefs.GetFloat(spawnPositionKey + "Z");

            playerObject.transform.position = new Vector3(spawnX, spawnY, spawnZ);

            DisableObjectsAndTeleport();
        }
    }

    private void DisableObjectsAndTeleport()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }

        Invoke("EnableObjects", disableDuration);

        playerObject.transform.position = spawnLocation.position;
    }

    private void EnableObjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(true);
        }
    }

    public void ResetSpawnPosition()
    {
        PlayerPrefs.DeleteKey(spawnPositionKey + "X");
        PlayerPrefs.DeleteKey(spawnPositionKey + "Y");
        PlayerPrefs.DeleteKey(spawnPositionKey + "Z");
    }
}