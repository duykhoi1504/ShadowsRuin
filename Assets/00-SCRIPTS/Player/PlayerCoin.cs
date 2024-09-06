using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerCoin : Singleton<PlayerCoin>
{
    [SerializeField] int currentCoin = 0;
    // [SerializeField] int currenDiamond ;

    public int CurrentCoin { get => currentCoin; set => currentCoin = value; }
    // public int CurrenDiamond { get => currenDiamond; set => currenDiamond = value; }

    private void Start()
    {
        // currenDiamond=GameManager.Instant.GameContentSO.Diamond;
        UIManager.Instant.UpdateCoinGUI(currentCoin);

        Coin.onCollectedCoin += AddCoin;
    }
    private void OnDestroy()
    {
        Coin.onCollectedCoin -= AddCoin;

    }
    private void Update()
    {
        UIManager.Instant.UpdateCoinGUI(currentCoin);
        // if(UIManager.Instance.diamondText!=null)
        // UIManager.Instance.UpdateDiamondGUI(CurrenDiamond);
    }
    public void AddCoin(int _coinToAdd)
    {
        currentCoin += _coinToAdd;

    }
    public void ReduceCoin(int _coinToAdd)
    {
        currentCoin -= _coinToAdd;

    }
}
