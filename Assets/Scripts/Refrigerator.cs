using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : MonoBehaviour
{
    public GameObject re_Open;

    private void OnMouseDown()
    {
        Debug.Log("마우스 클릭");
        gameObject.SetActive(false);
        re_Open.SetActive(true);

    }
}
