using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private GameContentSO gameContentSO;

    public List<Item> items;
    // public List<Item> ownedAbility;
    // public List<Transform> inventorySlot;
    public GameObject itemSlot;
    public Transform inventoryHolder;
    public Toggle EnableRemove;
    [Header("Ability")]
    // public List<Ability> abilities;
    public GameObject itemAbilitySlot;
    public Transform itemAbilityHolder;
    public bool isInLobby = false;

    // [Button]
    // public void SaveItem(){
    //     SaveSystem.Instant.SaveData();
    // }
    private void Start() {
        items=gameContentSO.Items;
    }
    public void ListItems()

    {

        // GameManager.Instant.ChangeState(GameState.INVENTORY);
        // checkQuantityZero();

        // inventorySlot = new List<Transform>();

        // foreach (Transform slot in inventoryHolder)
        // {
        //     Destroy(slot.gameObject);
        // }
        inventoryHolder.Clear();
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].quantity <= 0) return;
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
        // ListAbilityValid();
    }
    public void ListAbilityValid()
    {
        itemAbilityHolder.Clear();
        for (int i = 0; i < gameContentSO.Abilities.Count; i++)
        {
            if (gameContentSO.Abilities[i].IsBuy == false) continue;

            GameObject slot = Instantiate(itemAbilitySlot, itemAbilityHolder);
            slot.transform.GetChild(0).GetComponent<Image>().sprite = gameContentSO.Abilities[i].Image;
            slot.transform.GetChild(1).GetComponent<Text>().text = gameContentSO.Abilities[i].Name;
            //menu update ability khi chien dau
            if (slot.GetComponent<AbilitySlot>() != null)
            {
                // AbilitySlot slotComponent = slot.GetComponent<AbilitySlot>();
                slot.GetComponent<AbilitySlot>().ConfgiAbilitySLot(gameContentSO.Abilities[i]);
            }
        }

    }
    // public void CloseInventory()
    // {
    //     GameManager.Instant.ChangeState(GameState.GAMEPLAY);
    // }
    public void AddItem(Item item, int quantity)
    {
        if (items.Contains(item))
        {
            item.quantity += quantity;
        }
        else
        {
            items.Add(item);
            item.quantity += quantity;
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

