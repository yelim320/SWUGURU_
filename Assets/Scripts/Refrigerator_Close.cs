using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator_Close : MonoBehaviour
{
    public GameObject re_Open;
    public Transform player;


    private void OnMouseDown()
    {
        if (Vector3.Distance(player.position, transform.position) <= 3)
        {
            Debug.Log("���콺 Ŭ��");
            gameObject.SetActive(false);
            re_Open.SetActive(true);
        }

    }
}