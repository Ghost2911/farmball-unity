using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private GreenZone[] greenZones;
    private int greenZoneCount=0;

    void Start()
    {
        greenZones = GetComponentsInChildren<GreenZone>();
        greenZoneCount = greenZones.Length;
    }

    void Update()
    {
        int completeZone = 0;
        foreach(GreenZone gz in greenZones)
            completeZone += gz.isCompleted?1:0;
        if (completeZone == greenZoneCount)
            SceneManager.LoadScene(0);
    }
}
