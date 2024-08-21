using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    public ItemScriptableobject[] items;
    public Transform iventortHolder;
    public List<Transform> inventorySlot;

    private void Start()
    {
        inventorySlot = new List<Transform>();

        foreach (Transform slot in iventortHolder)
        {
            inventorySlot.Add(slot);
        }

        for (int i = 0; i < items.Length; i++)
        {
            Image imageComponent = inventorySlot[i].GetComponentInChildren<Image>();
            if (imageComponent != null && items[i].image != null)
            {
                inventorySlot[i].transform.GetChild(0).GetComponent<Image>().sprite=items[i].image;
            
            }
        }

    }
}

