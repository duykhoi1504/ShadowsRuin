using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Upgrades/Stats Upgrade")]
public class StatsUpgrade : Upgrade
{
       public StatInfo statInfo;
    public bool isPercentage;

    public override void DoUpgrade()
    {
        level++;
        // Logic to apply the stat upgrade
    }
}
[System.Serializable]
public class StatInfo
{
    public Stat statType;
    public float value;
}
public enum Stat
{
    MoveSpeed,
    Health
}