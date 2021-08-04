using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    GameObject gage;

    void Start()
    {
        GageManager.gage = 0;
        for (int i = 1; i < 6; i++)
        {
            GageManager.animator.ResetTrigger("level" + i);
            //Debug.Log(i);
        }
        GageManager.animator.SetTrigger("GameOver");
    }

    public void GameRestart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public static int GageReset()
    {
        return GageManager.gage;
    }
}
