using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageManager : MonoBehaviour
{
    public GameObject nextLevel;
    public int currentLevel;

    private void OnMouseDown()
    {
        if (currentLevel == 1)
        {
            gameObject.SetActive(false);
            nextLevel.SetActive(true);
        }

    }
}
