using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveInS2 : MonoBehaviour
{
    public GameObject cam;

    private void OnMouseDown()
    {
        cam.SetActive(true);
    }
}
