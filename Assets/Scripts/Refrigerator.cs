using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : MonoBehaviour
{
    public GameObject re_Open;

    private void OnMouseDown()
    {
        Debug.Log("���콺 Ŭ��");
        gameObject.SetActive(false);
        re_Open.SetActive(true);

    }
}
