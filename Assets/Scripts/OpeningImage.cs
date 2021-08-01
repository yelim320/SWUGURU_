using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningImage : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;

    float currentTime = 0;


    void Update()
    {
        currentTime += Time.deltaTime;

        image1.SetActive(true);
        if (currentTime >= 0.5f)
        {
            image1.SetActive(false);
            image2.SetActive(true);

            if (currentTime >= 1f)
            {
                image2.SetActive(false);
                image3.SetActive(true);

                if (currentTime >= 1.5f)
                {
                    image3.SetActive(false);
                    image4.SetActive(true);

                    if(currentTime >= 2f)
                    {
                        image4.SetActive(false);
                        image5.SetActive(true);
                    }
                }
            }
        }
    }
}
