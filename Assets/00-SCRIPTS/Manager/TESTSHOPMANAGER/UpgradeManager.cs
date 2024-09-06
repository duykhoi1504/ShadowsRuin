using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;
public class UpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UpgradeManager Instance { get; private set; }
    [SerializeField] UpgradeButton[] upgradeContainer;

    private void Awake()
    {
        Instance = this;
    }
    [NaughtyAttributes.Button]
    public void setButtonUpgrade()
    {
        for (int i = 0; i < upgradeContainer.Length; i++)
        {
            int randomIndex = Random.Range(0, Enum.GetValues(typeof(Stats)).Length);
            Stats stats = (Stats)Enum.GetValues(typeof(Stats)).GetValue(randomIndex);
            string RandomStatName = stats.ToString();
            // upgradeContainer[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = RandomStat;


            // string buttonString="";
        
           
            float RandomStat=Random.Range(0, 100);
            upgradeContainer[i].ButtonUpgradeSetUp(null,RandomStat.ToString() , RandomStatName);
            upgradeContainer[i].button.onClick.RemoveAllListeners();
            upgradeContainer[i].button.onClick.AddListener(() => GetActionToPerform(stats,RandomStat));
            upgradeContainer[i].button.onClick.AddListener(() =>GameManager.Instant.ChangeState(GameState.GAMEPLAY));

        }
    }


    public void GetActionToPerform(Stats stats,float value)
    {
        switch (stats)
        {
            case Stats.MoveSpeed:
                Debug.Log("MoveSpeed " + value);
                break;
            case Stats.Dodge:
                Debug.Log("Dodge " + value);
                break;
            case Stats.Attack:
                Debug.Log("Attack " + value);
                
                break;
            case Stats.Amor:
                Debug.Log("Amor " + value);
                break;
        }
    }

















    public string GetRandomStat()
    {
        // Lấy danh sách các giá trị trong enum Stats
        var statValues = Enum.GetValues(typeof(Stats));

        // Chọn một giá trị ngẫu nhiên
        var randomIndex = Random.Range(0, statValues.Length);
        var randomStat = (Stats)statValues.GetValue(randomIndex);

        // Trả về chuỗi tương ứng với giá trị ngẫu nhiên
        return randomStat.ToString();
        ////////////////////////////////////
        // Get an array of the enum member names

        // Randomly select an index
        // int randomIndex = Random.Range(0, Stats.GetValues(typeof(Stats)).Length);
        // Stats stat = (Stats)Enum.GetValues(typeof(Stats)).GetValue(randomIndex);
        // string randomStatsString = stat.ToString();

        // // Return the selected stat name
        // return randomStatsString;
    }
}
