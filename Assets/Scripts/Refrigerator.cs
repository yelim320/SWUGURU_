using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refrigerator : MonoBehaviour
{
    public GameObject re_Open;
    public GameObject item;
    private GameObject UIinventory;
    private GameObject PlayerItem;
    private GameObject textUI;
    private GameObject player;
    private Inventory inventory;
    private ItemWorld itemworld;

    private void Start()
    {
        player = GameObject.Find("Player");
        UIinventory = GameObject.Find("UI_Inventory");
        textUI = GameObject.Find("Inventory_Warning");
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 2)
        {
            Debug.Log("마우스 클릭");
            gameObject.SetActive(false);
            re_Open.SetActive(true);
            item.SetActive(true);

            /*if(inventory.itemList.Count == 5)
            {
                textUI.SetActive(true);
            }

            else
            {
                item.SetActive(true);
            }*/


        }

    }
}
