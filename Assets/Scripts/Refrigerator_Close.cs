using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator_Close : MonoBehaviour
{
    public GameObject re_Close;

    private void OnMouseDown()
    {
        Debug.Log("���콺 Ŭ��");
        gameObject.SetActive(false);
        re_Close.SetActive(true);

    }
}
