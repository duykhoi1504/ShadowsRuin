using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
   [SerializeField] private int cartCount = 3;

    public List<Upgrade> upgradeList;
    // public List<UIUpgrade> uiUpgrades;
    public TextMeshProUGUI reshuffleCostText;
    private int reshuffleCost = 3;
    [SerializeField] Transform parent;
    [SerializeField] UIUpgrade itemPrefab;
    public void InitializeShop()
    {
        foreach (var upgrade in upgradeList)
        {
            upgrade.level = 0;
        }
        ReShuffle();
    }
    private void Start() {
         InitializeShop();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.G)){
             ReShuffle();
        }
    }

    public void ReShuffle()
    {
        // foreach (var uiUpgrade in uiUpgrades)
        // {
        //     var randomUpgrade = upgradeList[Random.Range(0, upgradeList.Count)];
        //     uiUpgrade.SetUpgrade(randomUpgrade);
        //     uiUpgrade.SetCostTextColor();
        // }
        parent.Clear();
        for(int i = 0; i <cartCount;i++ ){
            var randomUpgrade = upgradeList[Random.Range(0, upgradeList.Count)];
            UIUpgrade item=Instantiate(itemPrefab,transform.position,Quaternion.identity,parent);
            item.SetUpgrade(randomUpgrade);
            item.SetCostTextColor();
        }
        // reshuffleCostText.text = reshuffleCost.ToString();
    }
}