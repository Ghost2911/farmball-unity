using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GreenZone : MonoBehaviour
{
    public int maxBalls = 10;
    private TextMeshProUGUI tm;
    private int ballCount = 0;
    public bool isCompleted = false;

    void Start()
    {
        tm = GetComponentInChildren<TextMeshProUGUI>();
        tm.text = ballCount+"/"+maxBalls;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballCount++;
            UpdatePresentor();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        { 
            ballCount--;
            UpdatePresentor();
        }
    }

    void UpdatePresentor()
    {
        isCompleted = (ballCount >= maxBalls);
        tm.text = ballCount+"/"+maxBalls;
        tm.color = (isCompleted)?Color.green:Color.red;
    }
}
