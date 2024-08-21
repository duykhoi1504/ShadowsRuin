using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Coin : DroppableBase
{
    [SerializeField] private int coinCount=5;
    public static Action<int> onCollectedCoin;
    protected override void Collected()
    {
        base.Collected();
            AudioManager.Instant.SFXVolumn(.5f);

        AudioManager.Instant.PlaySFX(CONTANST.pickupcoin);
        onCollectedCoin?.Invoke(coinCount);
    }
}
