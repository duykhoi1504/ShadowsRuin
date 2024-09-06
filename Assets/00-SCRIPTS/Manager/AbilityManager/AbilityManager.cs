using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class AbilityManager : Singleton<AbilityManager>
{



    // public List<AbilityData> abilityDatas = new List<AbilityData>();
    [Header("Inventpry Info")]
    [SerializeField] Transform ParentInventoryAbilityInfo;

    [SerializeField] GameObject abilitySlotInv;
    public List<AbilitySlot> abilityButton = new List<AbilitySlot>();


    [Header("Ability info")]

    public List<Ability> abilities = new List<Ability>();
    public List<AbilityUseSlot> abilityUseButton = new List<AbilityUseSlot>();

    // public List<AbilityData> Slots = new List<AbilityData>();
    // Ability dash, fireBall, pushAway;


    private void Start()
    {
        // ConfigAbility();
        ResetAbilities();
    }


    private void Update()
    {
        
        foreach (var a in abilities)
        {
            a.UpdateCoolDownTimer(Time.deltaTime);

        }

    }

    #region ability inventory

    //update display upgrade ability in inventory
    public void ListAbilitys()
    {
        // Clear the existing ability buttons
        foreach (AbilitySlot button in abilityButton)
        {
            Destroy(button.gameObject);
        }
        abilityButton.Clear();

        // Create new ability buttons
        for (int i = 0; i < abilities.Count; i++)
        {
            GameObject slot = Instantiate(abilitySlotInv, ParentInventoryAbilityInfo.transform.position, Quaternion.identity, ParentInventoryAbilityInfo.transform);
            AbilitySlot slotComponent = slot.GetComponent<AbilitySlot>();
            slotComponent.ConfgiAbilitySLot(abilities[i]);
            slotComponent.Ability = abilities[i];
            abilityButton.Add(slotComponent);
        }
    }
    #endregion



    #region ability


    //update display upgrade ability in Game
   public void ListAbilitysUse()
{
    List<Ability> availableAbilities = new List<Ability>(abilities); // Clone the abilities list

    // Loop through the ability use buttons
    for (int i = 0; i < abilityUseButton.Count; i++)
    {
        if (availableAbilities.Count == 0) 
        {
            Debug.LogWarning("No available abilities left to assign.");
            break; // Exit if no abilities are left
        }

        int randomIndex = Random.Range(0, availableAbilities.Count);
        Ability selectedAbility = availableAbilities[randomIndex];

        // Update the button display and ability
        abilityUseButton[i].UpgradeDisplayAbilityUse(selectedAbility);
        abilityUseButton[i].Ability = selectedAbility;
        abilityUseButton[i].Ability.UnClock = true;

        // Remove the selected ability from the list to avoid duplicates
        availableAbilities.RemoveAt(randomIndex);
    }
}

    // // use ability in game by index
    // public void UseAbilityByIndex(int index)
    // {
    //     if (index >= abilities.Count)
    //     {
    //         Debug.LogWarning("Khong tim thay ki nang");
    //         return;
    //     }
    //     if (abilities[index].UnClock == false)
    //     {
    //         Debug.LogWarning("ki nang chua mo khoa: " + abilities[index].name);
    //         return;
    //     }
    //     abilities[index].Use();
    // }
    public void UseAbility(Ability _ability)
    {
        Ability ability = abilities.Find(ad => ad == _ability);
        if (ability != null)
        {
            // The _ability is found in the abilityDatas list
            ability.Use();
        }
        else
        {
            Debug.LogWarning($"Ability {_ability.name} not found in abilityDatas list.");
        }
    }
    public void UpgradeAbilityStats(Ability ability)
    {
        ability.Level++;
        ability.SetStatsForUpGrade();

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
    public void ResetAbilities()
    {
        foreach (var a in abilities)
        {
            a.ResetData();
        }

        // Reconfigure abilities if necessary
        // ConfigAbility();
    }

    #endregion
}
