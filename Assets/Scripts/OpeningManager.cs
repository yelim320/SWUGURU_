using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningManager : MonoBehaviour
{
    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;
    public GameObject scene4;

    float currentTime = 0;

    void Update()
    {
        currentTime += Time.deltaTime;

        scene1.SetActive(true);
        if (currentTime >= 7)
        {
            scene1.SetActive(false);
            scene2.SetActive(true);

            if (currentTime >= 32)
            {
                scene2.SetActive(false);
                scene3.SetActive(true);

                if (currentTime >= 40)
                {
                    scene3.SetActive(false);
                    scene4.SetActive(true);
                }
            }
        }

    }

    public void OnMouseDown()
    {
        currentTime = 0;
        SceneManager.LoadScene("Tutorial");
    }
}
