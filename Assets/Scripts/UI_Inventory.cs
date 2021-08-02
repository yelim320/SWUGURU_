using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private GameObject player;
    private Vector3 itemDropPoint;
    public GameObject table;
    private float DisToTable;

    private AudioSource putAudio;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        player = GameObject.Find("Player");
        putAudio = GetComponent<AudioSource>();
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 85f;

        foreach (Items item in inventory.GetItemList())
        {
            //�κ��丮 ��ġ
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            //�����ۻ��
            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
                inventory.UseItem(item);
            };

            //��Ŭ���� �����۹�����
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
            {
                inventory.RemoveItem(item);
                DisToTable = Vector3.Distance(player.transform.position, table.transform.position);
                switch (item.itemType)
                {
                    case Items.ItemType.Watch:
                        if (DisToTable < 3)
                        {
                            itemDropPoint = table.transform.position;
                            itemDropPoint.y += 2;
                        }
                        else
                        {
                            itemDropPoint = player.transform.position;
                            itemDropPoint.x += 2;
                        }
                        break;

                    case Items.ItemType.DogSnack:
                        if (DisToTable < 3)
                        {
                            itemDropPoint = table.transform.position;
                            itemDropPoint.y += 2;
                        }
                        else
                        {
                            itemDropPoint = player.transform.position;
                            itemDropPoint.x += 2;
                        }
                        break;

                    default:
                        if (DisToTable < 2)
                        {
                            itemDropPoint = table.transform.position;
                        }
                        else
                        {
                            Debug.Log(DisToTable);
                            itemDropPoint = player.transform.position;
                            itemDropPoint.x += 2;
                        }
                        break;
                }
                
                ItemWorld.DropItem(itemDropPoint, item);
                putAudio.time = 0.75f;
                putAudio.Play();
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            x ++;
            if(x>5)
            { x = 0;

            }

            //������ �̹��� �ҷ�����
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
        }
    }
}
