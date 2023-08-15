using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public Text timeLevel_txt;
    private float timeLevel;
    public static bool sceneStarted;

    // Start is called before the first frame update
    void Start()
    {
        sceneStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneStarted)
        {
            timeLevel += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeLevel / 60);
            int seconds = Mathf.FloorToInt(timeLevel % 60);
            string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
            timeLevel_txt.text = formattedTime;
        }
    }
}
