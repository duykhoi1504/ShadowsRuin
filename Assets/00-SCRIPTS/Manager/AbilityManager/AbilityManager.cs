using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityManager : Singleton<AbilityManager>
{
    [System.Serializable]

    public class AbilityData
    {
        public string name;
        public Ability ability;
    }
    public List<AbilityData> abilityDatas = new List<AbilityData>();



    private void Update()
    {
        foreach (var a in abilityDatas)
        {
            a.ability.UpdateCoolDownTimer(Time.deltaTime);
        }
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

}
