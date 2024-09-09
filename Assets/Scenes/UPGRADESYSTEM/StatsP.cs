using System;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(menuName = "Stats")]
    public class StatsP : ScriptableObject
    {
        // public List<StatInfo> statInfo = new List<StatInfo>();

        // public void Upgrade(StatsUpgrade upgrade)
        // {
        //     switch(upgrade.statInfo.statType){
        //         case  Stat.Health:
                
        //             PlayerHealth.Instant.maxHealth+=PlayerHealth.Instant.health * (upgrade.statInfo.value / 100f);
        //         break;
        //          case  Stat.MoveSpeed:
        //             Player.Instant.moveSpeed+=1/upgrade.statInfo.value;
        //         break;
        //     }
        //     // this.upgradeApplied?.Invoke(upgrade);

        // }
        // private List<StatsUpgrade> appliedUpgrades = new List<StatsUpgrade>();

        // public event Action<StatsUpgrade> upgradeApplied;

        // public float GetStatValue(Stat stat)
        // {
        //     foreach (StatInfo item in statInfo)
        //     {
        //         if (item.statType == stat)
        //         {
        //             StatsUpgrade statsUpgrade = appliedUpgrades.Find((StatsUpgrade i) => i.statInfo.statType == stat);
        //             if (statsUpgrade == null)
        //             {
        //                 return item.value;
        //             }
        //             return (!statsUpgrade.isPercentage) ? (item.value + statsUpgrade.statInfo.value * (float)statsUpgrade.level) : (item.value + item.value * (statsUpgrade.statInfo.value * (float)statsUpgrade.level) / 100f);
        //         }
        //     }
        //     Debug.LogError($"No stat value found for {stat} on {base.name}");
        //     return 0f;
        // }


        // public void ResetUpgrades()
        // {
        //     appliedUpgrades.Clear();
        // }
    }
