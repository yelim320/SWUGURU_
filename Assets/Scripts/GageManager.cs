using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageManager : MonoBehaviour
{
    private int currentScore;
    public Text currentScoreUI;

    //private int lastScore;

    public static GageManager Instance = null;

    public int Ragegage
    {
        get { return currentScore; }
        set
        {
            currentScore = value;
            currentScoreUI.text = "�����г�ܰ� : " + currentScore;
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        //lastScore = PlayerPrefs.GetInt()
    }
}
