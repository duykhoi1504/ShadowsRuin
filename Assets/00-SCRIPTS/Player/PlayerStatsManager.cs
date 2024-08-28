using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerStats
{
    moveSpeed,
    maxHealth,
    pickUpRange,
    maxWeapons,
    health,
}
public class PlayerStatsManager : Singleton<PlayerStatsManager>
{
    [SerializeField] List<PlayerStatsValue> moveSpeed, maxHealth, health, pickUpRange, maxWeapons;
    public int moveSpeedCount, maxHealthCount, healthCount, pickUpRangeCount, maxWeaponsCount;


    public PlayerStatsUpgradeDisplay[] statsButton;

    private void Start()
    {
        int newCost = 0;
        float newValue = 0;
        //=========================MOVE SPEED==============================
        for (int i = moveSpeed.Count - 1; i < moveSpeedCount; i++)
        {

            ConfigNewCostAndValue(ref newCost, ref newValue, moveSpeed, i);
            moveSpeed.Add(new PlayerStatsValue(newCost, newValue));
        }
        //=========================MAX HEALTH==============================


        for (int i = maxHealth.Count - 1; i < maxHealthCount; i++)
        {
            ConfigNewCostAndValue(ref newCost, ref newValue, maxHealth, i);
            maxHealth.Add(new PlayerStatsValue(newCost, newValue));
        }
        //===========================HEALTH================================

        for (int i = health.Count - 1; i < healthCount; i++)
        {
            ConfigNewCostAndValue(ref newCost, ref newValue, health, i);
            health.Add(new PlayerStatsValue(newCost, newValue));
        }

    }
    void ConfigNewCostAndValue(ref int newCost, ref float newValue, List<PlayerStatsValue> _list, int i)
    {
        newCost = _list[i].cost + _list[1].cost;
        newValue = _list[i].value + (_list[1].value - _list[0].value);
    }



    public void SetStatsRandButton()
    {
        for (int i = 0; i < statsButton.Length; i++)
        {
            PlayerStats randomStat = (PlayerStats)Random.Range(0, System.Enum.GetValues(typeof(PlayerStats)).Length);
            PlayerStatsValue statValue = GetRandomStatValue(randomStat);
            statsButton[i].UpgradePlayerStatsButtonDisplay(statValue.cost, statValue.value, randomStat.ToString(), randomStat);
        }
    }
    public void updateStatsShopDisplayer()
    {
        for (int i = 0; i < statsButton.Length; i++)
        {

            statsButton[i].updateDisplayWhenClicked();
        }
    }
    private PlayerStatsValue GetRandomStatValue(PlayerStats stat)
    {
        List<PlayerStatsValue> statList = null;

        switch (stat)
        {
            case PlayerStats.moveSpeed:
                statList = moveSpeed;
                break;
            case PlayerStats.maxHealth:
                statList = maxHealth;
                break;
            case PlayerStats.pickUpRange:
                statList = pickUpRange;
                break;
            case PlayerStats.maxWeapons:
                statList = maxWeapons;
                break;
            case PlayerStats.health:
                statList = health;

                break;
        }

        if (statList != null && statList.Count > 0)
        {
            return statList[Random.Range(0, statList.Count)];
        }

        return new PlayerStatsValue(0, 0);
    }

    // public void SetStatsRandButton()
    // {
    //     for (int i = 0; i < statsButton.Length; i++)
    //     {

    //         statsButton[i].UpgradePlayerStatsButtonDisplay()
    //     }
    // }
}



[System.Serializable]
public class PlayerStatsValue
{
    public int cost;
    public float value;
    public PlayerStatsValue(int newCost, float newValue)
    {
        cost = newCost;
        value = newValue;
    }
}