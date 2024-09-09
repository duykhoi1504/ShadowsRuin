using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Upgrades/Stats Upgrade")]
public class StatsUpgrade : Upgrade
{
    // public List<StatInfo> statInfo = new List<StatInfo>();
    // public List<StatsP> statsToUpgrade;
    public StatInfo statInfo;
    public bool isPercentage;

    public override void DoUpgrade()
    {
        level++;
        Upgrade(this);

    }
    public void Upgrade(StatsUpgrade upgrade)
    {
        switch (upgrade.statInfo.statType)
        {
            case Stat.Health:

                PlayerHealth.Instant.maxHealth += PlayerHealth.Instant.health * (upgrade.statInfo.value / 100f);
                break;
            case Stat.MoveSpeed:
                Player.Instant.moveSpeed += 2 / upgrade.statInfo.value;
                break;
        }
        // this.upgradeApplied?.Invoke(upgrade);

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