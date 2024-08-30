using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public List<Upgrade> upgradeList;
    public List<UIUpgrade> uiUpgrades;
    public TextMeshProUGUI reshuffleCostText;
    private int reshuffleCost = 3;

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
        if(Input.GetKey(KeyCode.G)){
             ReShuffle();
        }
    }

    public void ReShuffle()
    {
        foreach (var uiUpgrade in uiUpgrades)
        {
            var randomUpgrade = upgradeList[Random.Range(0, upgradeList.Count)];
            uiUpgrade.SetUpgrade(randomUpgrade);
            uiUpgrade.SetCostTextColor();
        }
        reshuffleCostText.text = reshuffleCost.ToString();
    }
}