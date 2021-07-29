using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageManager : MonoBehaviour
{

    public Text stateLabel;

    public enum RageLevel
    {
        level1, level2, level3, level4, Gameover
    }

    public RageLevel RLevel;
    public static int plevel;

    public int firstLevel = 0;
    private int currentLevel;

    public Animator nextLevel;

    public GameObject levelUp;

    private void Awake()
    {
        plevel = firstLevel;
    }

    void Start()
    {
    }

    public int Getlevel()
    {
        return currentLevel;
    }
    public void Setlevel(int value)
    {
        currentLevel++;
        gameObject.SetActive(false);
        if (currentLevel == 1)
        {
            nextLevel.SetTrigger("");
        }
        if (currentLevel == 2)
        {
            nextLevel.SetTrigger("level2");
        }
        if (currentLevel == 3)
        {
            nextLevel.SetTrigger("level3");
        }
        if (currentLevel == 4)
        {
            nextLevel.SetTrigger("level4");
        }

        levelUp.SetActive(true);
    }

    void Update()
    {
        if (currentLevel == 5)
        {
            nextLevel.SetTrigger("level5");
            stateLabel.text = "Game Over...";
            stateLabel.color = new Color32(255, 0, 0, 255);
            Time.timeScale = 0;
            RLevel = RageLevel.Gameover;
        }
    }
}
