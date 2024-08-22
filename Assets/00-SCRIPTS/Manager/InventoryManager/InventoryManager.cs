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
        }
        GameManager.Instance.ChangeState(GameState.INVENTORY);
    }
    public void CloseInventory()
    {
        GameManager.Instance.ChangeState(GameState.GAMEPLAY);
    }
    public void AddItem(Item item)
    {
        items.Add(item);
    }
    public void RemmoveItem(Item item)
    {
        items.Remove(item);
    }
    public void EnableItemRemove(){
        if(EnableRemove.isOn){
            foreach(Transform item in inventoryHolder){
                item.transform.GetChild(3).gameObject.SetActive(true);
            }
        }
        else{
            foreach(Transform item in inventoryHolder){
                item.transform.GetChild(3).gameObject.SetActive(false);
            }
        }
    }
}

