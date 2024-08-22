using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] Item item;
   private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Player>() != null){
            InventoryManager.Instant.AddItem(item);
            this.gameObject.SetActive(false);   
        }
   }
}
