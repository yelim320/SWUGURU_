using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator_Close : MonoBehaviour
{
    public GameObject re_Close;

    private void OnMouseDown()
    {
        Debug.Log("마우스 클릭");
        gameObject.SetActive(false);
        re_Close.SetActive(true);

    }
}
