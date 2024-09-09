using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NaughtyAttributes;
public enum StyleItem
{
    Medicine,
    Ability,
}
public class ShopManager : Singleton<ShopManager>
{
    [SerializeField] List<Item> items = new List<Item>();
    [SerializeField] List<Ability> abilitys = new List<Ability>();


    public Action onOpenShop;
    public bool canOpen;
    [SerializeField] private GameObject lobbyShopPanel;

    [SerializeField] UIItem itemPrefab;
    [SerializeField] UIItem itemAbilityPrefab;


    [SerializeField] Transform parentToSpawn;

    public List<Ability> Abilitys { get => abilitys; set => abilitys = value; }

    public StyleItem styleItem;


    void Start()
    {
        canOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && canOpen)
        {
            lobbyShopPanel.SetActive(true);
            LoadItem();
        }

    }

    public void LoadItem()
    {
        styleItem = StyleItem.Medicine;
        parentToSpawn.Clear();

        foreach (var a in items)
        {
            UIItem item = Instantiate(itemPrefab, transform.position, Quaternion.identity, parentToSpawn);
            item.ConfigItem(a);
        }
    }

    public void LoadItemAbility()
    {
        styleItem = StyleItem.Ability;
        parentToSpawn.Clear();
        foreach (var a in Abilitys)
        {
            if (a.IsBuy == true) { continue; }
            UIItem item = Instantiate(itemAbilityPrefab, transform.position, Quaternion.identity, parentToSpawn);
            item.ConfigItem(a);
        }
    }
    [Button]
    public void ResetShop()
    {
        foreach (var a in Abilitys)
        {
            a.IsBuy = false;

        }
    }
}
