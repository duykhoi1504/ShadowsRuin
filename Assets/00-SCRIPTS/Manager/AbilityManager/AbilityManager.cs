using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [System.Serializable]
    public class AbilityData
    {
        public string name;
        public Ability ability;
    }
    [SerializeField] private GameObject vfx;

    public List<AbilityData> abilityDatas=new List<AbilityData>();

    private void Update() {
        foreach (var a in abilityDatas)
        {
            a.ability.UpdateCoolDownTimer(Time.deltaTime);
        }
    
        if(Input.GetKeyDown(KeyCode.Q)){
            UseAbility(0);
      
        }
if(Input.GetKeyDown(KeyCode.E)){
            UseAbility(1);
      
        }
    }
    public void UseAbility(int index){
            if(index>=abilityDatas.Count)return;
            if(abilityDatas[index].ability.UnClock==false){
                Debug.LogWarning("ki nang chua mo khoa: "+abilityDatas[index].ability.name );
                return;
            }
            abilityDatas[index].ability.Use();
    }

}
