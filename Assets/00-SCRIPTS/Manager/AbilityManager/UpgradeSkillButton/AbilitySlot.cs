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
    [SerializeField] Image levelDot;
    [SerializeField] List<Image> levelDots = new List<Image>();
    // [SerializeField] Image image => transform.GetChild(0).GetComponent<Image>();
    [SerializeField] Transform levelPanel;
    // [SerializeField] TextMeshProUGUI text => transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    [SerializeField] TextMeshProUGUI cost;

    public Ability Ability { get => ability; set => ability = value; }

    public Button button;
    private void Start()
    {
        // button = this.GetComponent<Button>();
        // UpgradeDisplayAbility();
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
        UpgradeDisplayAbility();
    }

    private void BuyUpgradeAbility()
    {
        int cost = ability.abilityStats[ability.Level + 1].cost;
        if (PlayerCoin.Instant.CurrentCoin >= cost && ability.UnClock && ability.Level <= ability.abilityStats.Count - 1)
        {
            AbilityManager.Instant.UpgradeAbilityStats(ability);
            PlayerCoin.Instant.ReduceCoin(cost);
            UpgradeDisplayAbility();
        }
        else
        {
            Debug.LogWarning(" Cannot upgrade ability: Insufficient coins or ability is already at maximum level. ");
        }
    }

  public void UpgradeDisplayAbility()
{
    Debug.Log("Starting UpgradeDisplayAbility");

    if (ability == null)
    {
        Debug.LogError("Ability is not assigned.");
        return;
    }

    if (levelDots == null)
    {
        Debug.LogError("LevelDots list is not assigned.");
        return;
    }

    if (levelDot == null)
    {
        Debug.LogError("LevelDot prefab is not assigned.");
        return;
    }

    if (levelPanel == null)
    {
        Debug.LogError("LevelPanel is not assigned.");
        return;
    }

    if (button == null)
    {
        Debug.LogError("Button is not assigned.");
        return;
    }

    if (!ability.UnClock)
    {
        button.enabled = false;
        return;
    }
    else
    {
        int currentLevel = ability.Level;
        int maxLevel = ability.abilityStats.Count - 1;
        Debug.Log($"Current Level: {currentLevel}, Max Level: {maxLevel}");

        // Clear the existing level dots
        foreach (Image dot in levelDots)
        {
            if (dot != null)
            {
                Destroy(dot.gameObject);
            }
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
            cost.text = "MAX";
        }
        else
        {
            cost.text = ability.abilityStats[currentLevel + 1].cost.ToString();
        }
    }

    Debug.Log("Finished UpgradeDisplayAbility");
}
}
