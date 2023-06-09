using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeZoneScript : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text militaryTimeText;
    public TMP_Text dayText;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = System.DateTime.Now.ToString("h:mm tt");
        militaryTimeText.text = System.DateTime.Now.ToString("HH:mm");
        dayText.text = System.DateTime.Now.ToString("dddd, MMMM dd yyyy");
    }
}