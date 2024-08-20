using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerCoin :Singleton<PlayerCoin>
{
    [SerializeField] int currentCoin=0;

    public int CurrentCoin { get => currentCoin; set => currentCoin = value; }

    private void Start()
    {
        UIManager.Instance.UpdateCoinGUI(currentCoin);

        Coin.onCollectedCoin += AddCoin;
    }
    private void Update() {
        UIManager.Instance.UpdateCoinGUI(currentCoin);
    }
    private void OnDestroy()
    {
        Coin.onCollectedCoin -= AddCoin;

    }
    public void AddCoin(int _coinToAdd)
    {
        currentCoin += _coinToAdd;
        
    }
}
