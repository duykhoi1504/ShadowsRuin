using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ShopManager : Singleton<ShopManager>
{
    [SerializeField]  List<Item> items= new List<Item>();
    
    public Action onOpenShop;
    public bool canOpen;
     [SerializeField] private GameObject lobbyShopPanel;

   [SerializeField] UIItem itemPrefab;
   [SerializeField] Transform parentToSpawn;
    void Start()
    {
        canOpen=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E ) && canOpen){
            lobbyShopPanel.SetActive(true);
            LoadItem();
        }
        
    }

public void LoadItem(){
    foreach(Transform a in parentToSpawn){
        Destroy(a.gameObject);
    }
    foreach(var a in items){
        UIItem item=Instantiate(itemPrefab,transform.position,Quaternion.identity,parentToSpawn);
        item.ConfigItem(a);
    }
}
}
