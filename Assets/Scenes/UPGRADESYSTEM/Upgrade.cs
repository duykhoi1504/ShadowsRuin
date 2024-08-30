using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Upgrade : ScriptableObject
{
    public Sprite icon;
    public string upgradeName;
    public string description;
    public int baseCost;
    public int level;

    public abstract void DoUpgrade();
}
