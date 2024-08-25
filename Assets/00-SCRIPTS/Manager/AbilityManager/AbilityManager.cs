using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class AbilityManager : Singleton<AbilityManager>
{

    [System.Serializable]

    public class AbilityData
    {
        public Ability ability;
        public AbilityType type;
    }
    public List<AbilityData> abilityDatas = new List<AbilityData>();
    public List<GameObject> abilityButton = new List<GameObject>();
    // public List<AbilityData> Slots = new List<AbilityData>();
    Ability dash, fireBall, pushAway;
    private void Start()
    {
ConfigAbility();
    }

    private void Update()
    {
        foreach (var a in abilityDatas)
        {
            a.ability.UpdateCoolDownTimer(Time.deltaTime);

        }
        // for (int i = 0; i < abilityButton.Count; i++)
        // {
        //     GameObject button = abilityButton[i];

        //     for (int j = 0; j < abilityDatas.Count; j++)
        //     {
        //         if (!Slots.Contains(abilityDatas[j]))
        //         {
        //             if (abilityDatas[j].ability.UnClock)
        //             {

        //                 Slots.Add(abilityDatas[j]);
        //                 button.transform.GetChild(0).GetComponent<Image>().sprite = abilityDatas[j].ability.Image;
        //                 button.transform.GetComponent<Button>().onClick.AddListener(() => abilityDatas[j].ability.Use());
        //                 break;
        //             }
        //         }
        //         else
        //         {
        //             continue;
        //         }
        //     }

        // }
    }


    public void UseAbility(int index)
    {
        if (index >= abilityDatas.Count)
        {
            Debug.LogWarning("Khong tim thay ki nang");
            return;
        }
        if (abilityDatas[index].ability.UnClock == false)
        {
            Debug.LogWarning("ki nang chua mo khoa: " + abilityDatas[index].ability.name);
            return;
        }
        abilityDatas[index].ability.Use();
    }

    public void UpgradeAbilityStats(AbilityType type)
    {
        switch (type)
        {
            case AbilityType.Dash:

                dash.Level++;
                break;
            case AbilityType.FireBall:

                fireBall.Level++;
                break;
            case AbilityType.PushAway:

                pushAway.SetStatsForUpGrade();
                
                break;
            default:
                Debug.Log("khong co skill for update");
                break;
        }
    }
    private void ConfigAbility()
    {
        foreach (var a in abilityDatas)
        {
            switch (a.type)
            {
                case AbilityType.Dash:
                    dash = a.ability;
                    break;
                case AbilityType.FireBall:
                    fireBall = a.ability;

                    break;
                case AbilityType.PushAway:
                    pushAway = a.ability;
                    break;
                default:
                    break;
            }
        }
    }
    public void OnButtonDown()
    {
        // Khi nhấn giữ nút, làm chậm thời gian
        Time.timeScale = .2f;
        //fixedDeltaTime Giúp tránh các vấn đề như tính toán vật lý không chính xác khi thời gian bị làm chậm hoặc tăng tốc.
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    public void OnButtonUp()
    {
        // Khi nhấn giữ nút, làm chậm thời gian
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

}
