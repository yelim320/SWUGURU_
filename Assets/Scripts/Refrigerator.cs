using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : MonoBehaviour
{
    public GameObject re_Open;
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(player.position, transform.position) <= 2)
        {
            Debug.Log("���콺 Ŭ��");
            gameObject.SetActive(false);
            re_Open.SetActive(true);
            item.SetActive(true);
        }

    }
}
