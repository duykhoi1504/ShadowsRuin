// using System;
// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using Unity.VisualScripting.Antlr3.Runtime.Misc;
// using UnityEngine;
// using UnityEngine.UI;

// using Random = UnityEngine.Random;
// public class UpgradeManager : MonoBehaviour
// {
//     // Start is called before the first frame update
//     [SerializeField] Button[] upgradeContainer;

//     public void setButtonUpgrade()
//     {
//         for (int i = 0; i < upgradeContainer.Length; i++)
//         {
//             // upgradeContainer[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text="Upgrade "+i+1;
//             upgradeContainer[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = GetRandomStat();

//         }
//     }
//     public string GetRandomStat()
//     {
//         // Get an array of the enum member names

//         // Randomly select an index
//         int randomIndex = Random.Range(0, Stats.GetValues(typeof(Stats)).Length);
//         Stats stat = (Stats)Enum.GetValues(typeof(Stats)).GetValue(randomIndex);
//         string randomStatsString = stat.ToString();

//         // Return the selected stat name
//         return randomStatsString;
//     }
// }
