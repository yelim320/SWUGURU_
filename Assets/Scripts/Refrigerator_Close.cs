using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator_Close : MonoBehaviour
{
    public GameObject re_Open;
    private Transform player;
    public GameObject item;

    private void Start()
    {
        player = GameObject.Find("SWUNIE").transform;
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(player.position, transform.position) <= 3)
        {
            if (Vector3.Distance(item.transform.position, transform.position) >= 3)
            {
                item.SetActive(true);
            }

            else
            {
                item.SetActive(false);
            }

            Debug.Log("마우스 클릭");
            gameObject.SetActive(false);
            re_Open.SetActive(true);
            item.SetActive(false);
        }

    }
}
