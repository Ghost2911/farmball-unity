using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI tmLevel;
    public GameObject menuPanel;
    AudioSource audioSource;

    void Start()
    {
        tmLevel.text = "Location " + SceneManager.GetActiveScene().buildIndex;
        audioSource = Camera.main.GetComponent<AudioSource>();
        audioSource.mute = Convert.ToBoolean(PlayerPrefs.GetInt("audio", 0));
        menuPanel.SetActive(false);
    }

    public void ChangeMusic()
    {
        audioSource.mute = !audioSource.mute;
        PlayerPrefs.SetInt("audio", Convert.ToInt32(audioSource.mute));
        PlayerPrefs.Save();
    }

    public void Leave()
    {
        Application.Quit();
    }

    public void ChangeMenuVisible()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        Debug.Log(menuPanel.activeSelf);
    }
}
