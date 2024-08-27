using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlot : MonoBehaviour
{
    // [SerializeField] private AbilityType abilityType;
    [SerializeField] private Ability ability;
    [SerializeField] Transform levelPanel => transform.GetChild(2).GetComponent<Transform>();
    [SerializeField] Image levelDot;
    [SerializeField] List<Image> levelDots = new List<Image>();
    [SerializeField] Image image => transform.GetChild(0).GetComponent<Image>();
    [SerializeField] TextMeshProUGUI text => GetComponentInChildren<TextMeshProUGUI>();

    public Ability Ability { get => ability; set => ability = value; }

    public Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        UpgradeDisplayAbility();
        button.onClick.RemoveAllListeners();


        button.onClick.AddListener(() => BuyUpgradeAbility());

    }
    public void UpgradeAbility()
    {
        AbilityManager.Instant.UpgradeAbilityStats(ability);
    }

    // public void UseAbilitySlot()
    // {
    //     AbilityManager.Instant.UpgradeAbilityStats(ability);
    // }
    public void ConfgiAbilitySLot(Ability _ab)
    {
        ability = _ab;
    }

private void BuyUpgradeAbility()
{
    int cost = ability.abilityStats[ability.Level].cost;
    if (PlayerCoin.Instant.CurrentCoin >= cost && ability.UnClock && ability.Level <= ability.abilityStats.Count - 1)
    {
        AbilityManager.Instant.UpgradeAbilityStats(ability);
        PlayerCoin.Instant.ReduceCoin(cost);
        UpgradeDisplayAbility();
    }
    else
    {
        Debug.LogWarning("Cannot upgrade ability: Insufficient coins or ability is already at maximum level.");
    }
}

    public void UpgradeDisplayAbility()
    {

        text.text = ability.name;
        image.sprite = ability.Image;

        if (!ability.UnClock)
        {
            button.enabled = false;
            return;
        }
        else
        {
            int currentLevel = ability.Level ;
            int maxLevel = ability.abilityStats.Count-1;
            
            // Clear the existing level dots
            foreach (Image dot in levelDots)
            {
                Destroy(dot.gameObject);
            }
            levelDots.Clear();

            // Create new level dots
            for (int i = 0; i < maxLevel; i++)
            {
                Image dot = Instantiate(levelDot, levelPanel.transform);
                dot.color = i < currentLevel ? Color.green : Color.red;
                levelDots.Add(dot);
            }
            if (currentLevel >= maxLevel)
            {
                button.enabled = false;
            }
        }
    }
}
