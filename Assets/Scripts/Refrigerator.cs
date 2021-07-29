using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : MonoBehaviour
{
    public GameObject re_Open;
    public Transform player;

    private void OnMouseDown()
    {
        if (Vector3.Distance(player.position, transform.position) <= 3)
        {
            Debug.Log("마우스 클릭");
            gameObject.SetActive(false);
            re_Open.SetActive(true);
        }

    }
}
