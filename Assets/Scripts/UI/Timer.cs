using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool isTimerActive = true;

    private float time = 0.0f;

    void Start()
    {
        time = 0.0f;
    }
    void Update()
    {
        if (!isTimerActive)
        {
            return;
        }

        time += Time.deltaTime;
        
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{01:00}", minutes, seconds);
    }
}
