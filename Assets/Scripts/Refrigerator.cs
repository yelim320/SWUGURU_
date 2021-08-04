using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refrigerator : MonoBehaviour
{
    public GameObject re_Open;
    public GameObject item;
    public GameObject sound;
    private GameObject UIinventory;
    private GameObject PlayerItem;
    private GameObject textUI;
    private GameObject player;
    private Inventory inventory;
    private ItemWorld itemworld;
    //private int count = 0;

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
            //count++;
            Debug.Log("마우스 클릭");
            sound.SetActive(true);
            gameObject.SetActive(false);
            re_Open.SetActive(true);
           
            /* if(count > 1)
             {
                 item.SetActive(false);
             }
             else*/
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
