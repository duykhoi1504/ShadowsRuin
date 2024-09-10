using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IItemSlot
{
    [SerializeField] public Item item;
    [SerializeField] Button removeItems;


    public string Name => item.name;
    public string Description => item.description;
    public Sprite Image => item.image;

    public void AddItem(Item newItem)
    {
        item = newItem;
    }
    public void RemmoveItem()
    {
        InventoryManager.Instant.RemmoveItem(item);
        Destroy(gameObject);

    }
    public void UseItem()
    {


        item.quantity--;
        switch (item.itemType)
        {
            case ItemType.Postion:
                PlayerHealth.Instant.health += item.value;
                break;
            case ItemType.Speed:
                Player.Instant.moveSpeed += item.value;
                break;
        }
        if (item.quantity <= 0)
        {
            item.quantity = 0;
            RemmoveItem();
        }
        InventoryManager.Instant.ListItems();

    }
}
