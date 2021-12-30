using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class FinishZone: MonoBehaviour
{
    public Transform scorePosition;
    public Transform endPosition;
    private FollowCamera cam;
    private int maxBalls;
    private TextMeshProUGUI tm;
    private int ballCount = 0;

    void Start()
    { 
        cam = Camera.main.GetComponent<FollowCamera>();
        tm = GetComponentInChildren<TextMeshProUGUI>();
        maxBalls = GameObject.FindGameObjectsWithTag("Ball").Length;
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
        tm.text = ballCount+"/"+maxBalls;
        if (ballCount >= maxBalls)
            StartCoroutine(NextSceneLoad());
    }

    IEnumerator NextSceneLoad()
    {
        cam.target = scorePosition;
        yield return new WaitForSeconds(3f);
        cam.followSpeed = 0.1f;
        cam.target = endPosition;
        yield return new WaitForSeconds(2f);
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            PlayerPrefs.SetInt("level", activeSceneIndex + 1);
            SceneManager.LoadScene(activeSceneIndex + 1);
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
            SceneManager.LoadScene(0);
        }
        PlayerPrefs.Save();
    }
}
