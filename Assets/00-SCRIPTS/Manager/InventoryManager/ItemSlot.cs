using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]Item item;
    [SerializeField]Button removeItems;

    public void AddItem(Item newItem){
        item=newItem;
    }
    public void RemmoveItem(){
        InventoryManager.Instant.RemmoveItem(item);
        Destroy(gameObject);

    }
}
