using UnityEngine;

public class MusicTimeZones : MonoBehaviour
{
    public AudioSource audioSource;
    public Vector2[] musicTimes;

    private void Start()
    {
        InvokeRepeating("CheckTimeAndPlayMusic", 0f, 60f);
    }

    private void CheckTimeAndPlayMusic()
    {
        int currentHour = System.DateTime.Now.Hour;
        int currentMinute = System.DateTime.Now.Minute;


        for (int i = 0; i < musicTimes.Length; i++)
        {
            int targetHour = (int)musicTimes[i].x;
            int targetMinute = (int)musicTimes[i].y;

            if (currentHour == targetHour && currentMinute >= targetMinute && currentMinute < targetMinute + 1)
            {

                audioSource.Play();
                break;
            }
        }
    }

}
