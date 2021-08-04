using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public void GameRestart()
    {
        GageManager.gage = 0;
        GageManager.animator.SetTrigger("GameOver");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
