using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : Singleton<InventoryManager>
{
    public List<Item> items;
    // public List<Transform> inventorySlot;
    public GameObject itemSlot;
    public Transform inventoryHolder;
    public Toggle EnableRemove;


    private void Start()
    {

    }
    public void ListItems()
    {
        GameManager.Instance.ChangeState(GameState.INVENTORY);
        // checkQuantityZero();

        // inventorySlot = new List<Transform>();

        foreach (Transform slot in inventoryHolder)
        {
            Destroy(slot.gameObject);
        }

        for (int i = 0; i < items.Count; i++)
        {
            GameObject slot = Instantiate(itemSlot, inventoryHolder);
            // inventorySlot.Add(slot.transform);
            slot.GetComponent<ItemSlot>().AddItem(items[i]);
            Image imageComponent = slot.GetComponentInChildren<Image>();
            if (imageComponent != null && items[i].image != null)
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite = items[i].image;
                slot.transform.GetChild(1).GetComponent<Text>().text = items[i].name;
                slot.transform.GetChild(2).GetComponent<Text>().text = items[i].quantity.ToString();
            }
            // if(items[i].quantity<=0){
            //     items[i].quantity=0;
            //     RemmoveItem(items[i]);
            // }
        }
    }
    public void CloseInventory()
    {
        GameManager.Instance.ChangeState(GameState.GAMEPLAY);
    }
    public void AddItem(Item item, int quantity)
    {
        if (items.Contains(item))
        {
            item.quantity += quantity;
        }
        else
        {
            items.Add(item);
            // item.quantity=item.quantity<=0?1:1;
            // item.quantity = 1;
        }
        // foreach (Item a in items)
        // {
        //     if (a == item)
        //     {
        //         a.quantity += quantity;
        //         return;
        //     }

        // }
        // items.Add(item);
    }
    public void RemmoveItem(Item item)
    {
        items.Remove(item);
    }
    public void EnableItemRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach (Transform item in inventoryHolder)
            {
                item.transform.GetChild(3).gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in inventoryHolder)
            {
                item.transform.GetChild(3).gameObject.SetActive(false);
            }
        }
    }
}

