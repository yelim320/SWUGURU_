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

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        player = GameObject.Find("Player");
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
        float itemSlotCellSize = 100f;

        foreach (Items item in inventory.GetItemList())
        {
            //인벤토리 배치
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            //아이템사용
            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
                inventory.UseItem(item);
            };

            //우클릭시 아이템버리기
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
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            x ++;
            if(x>5)
            { x = 0;

            }

            //아이템 이미지 불러오기
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
        }
    }
}
