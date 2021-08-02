using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public void GameRestart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
