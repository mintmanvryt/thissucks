using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using easyInputs;

public class Sandbox : MonoBehaviour
{
    [Header("MADE BY RATEIX GIVE CREDIT EVEN IF EDITED")]
    
    public List<GameObject> prefabs;
    public Transform itemSpawnPoint;
    public TMP_Text itemText;

    public int currentIndex = 0;

    private bool canSpawn = true;
    public float spawnDelay = 1f;

    void Start()
    {
        DisplayItem();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTag"))
        {
            if (EasyInputs.GetPrimaryButtonTouched(EasyHand.RightHand))
            {
                currentIndex = (currentIndex + 1) % prefabs.Count;
                DisplayItem();
            }
            else if (EasyInputs.GetSecondaryButtonTouched(EasyHand.RightHand))
            {
                currentIndex = (currentIndex - 1 + prefabs.Count) % prefabs.Count;
                DisplayItem();
            }
        }
    }

    public void DisplayItem()
    {
        itemText.text = "Current Item: " + prefabs[currentIndex % prefabs.Count].name;
    }

    IEnumerator SpawnDelay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnDelay);
        canSpawn = true;
    }

    void Update()
    {
        if (EasyInputs.GetTriggerButtonDown(EasyHand.RightHand) && canSpawn)
        {
            Instantiate(prefabs[currentIndex], itemSpawnPoint.position, itemSpawnPoint.rotation);
            StartCoroutine(SpawnDelay());
        }
    }
}
