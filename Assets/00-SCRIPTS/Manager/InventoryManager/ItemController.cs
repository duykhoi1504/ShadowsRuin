using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] private int quantity;
    private void Start() {
        if(item.quantity<0){
            item.quantity = 0;
        }
    }
   private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Player>() != null){
            InventoryManager.Instant.AddItem(item,quantity);
            this.gameObject.SetActive(false);   
            
        }
   }
}
