using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level",1));
    }
}
