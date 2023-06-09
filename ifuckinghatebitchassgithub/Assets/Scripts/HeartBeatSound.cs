using UnityEngine;

public class HeartBeatSound : MonoBehaviour
{
    public Transform target;
    public float minDistance = 1.0f;
    public float maxDistance = 10.0f;
    public float minPitch = 1.0f;
    public float maxPitch = 2.0f;
    public AudioSource audioSource;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        float t = Mathf.InverseLerp(minDistance, maxDistance, distance);
        float pitch = Mathf.Lerp(minPitch, maxPitch, t);
        audioSource.pitch = pitch;
    }
}
