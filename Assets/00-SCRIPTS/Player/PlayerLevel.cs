using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class PlayerLevel : Singleton<PlayerLevel>
{
    // Start is called before the first frame update
    [SerializeField] private int requireXP;
    [SerializeField] private int currentXP;
    [SerializeField] private int level;
    [SerializeField] private bool isLevelUp;

    public int RequireXP { get => requireXP; set => requireXP = value; }
    public int CurrentXP { get => currentXP; set => currentXP = value; }
    public int Level { get => level; set => level = value; }
    public bool IsLevelUp { get => isLevelUp; set => isLevelUp = value; }

    void Start()
    {
        IsLevelUp = false;
        Exp.onCollectedEXP += UpdateCurrentXP;
        UpdateRequireXP();
        UIManager.Instant.UpdateXPGUI( CurrentXP, RequireXP, Level);
    }
    private void OnDestroy()
    {
        Exp.onCollectedEXP -= UpdateCurrentXP;

    }
    // Update is called once per frame
    void UpdateRequireXP()
    {
        RequireXP = (Level + 1) * 5;
    }
    // void UpdateGUI()
    // {
    //     sliderXP.value = (float)currentXP / requireXP;
    //     text.text = "level " + (level + 1);
    // }
    private void UpdateCurrentXP(Exp exp)
    {
        CurrentXP++;
        if (CurrentXP >= RequireXP)
        {
            // Debug.Log(exp.gameObject.name);
            IsLevelUp = true;
            CurrentXP = 0;
            Level++;
            UpdateRequireXP();
            // GameManager.Instance.ChangeState(GameState.SHOP);

        }
         UIManager.Instant.UpdateXPGUI( CurrentXP, RequireXP, Level);
        // UIManager.Instance.levelUpButon[0].UpdateButtonDisplay(PlayerManager.Instance.assignedwWeapons[0].GetComponent<Weapon>());
        // UIManager.Instance.levelUpButon[1].UpdateButtonDisplay(PlayerManager.Instance.unAssignedWeapons[0].GetComponent<Weapon>());
        // UIManager.Instance.levelUpButon[2].UpdateButtonDisplay(PlayerManager.Instance.unAssignedWeapons[1].GetComponent<Weapon>());


        // // Giả sử đã có 3 kỹ năng mở khóa
        // List<Weapon> chosenWeapon = new List<Weapon>();

        // while (chosenWeapon.Count < UIManager.Instance.levelUpButon.Length)
        // {
        //     Weapon randomAbility = PlayerManager.Instance.assignedwWeapons[Random.Range(0, allAbilities.Count)];
        //     if (!chosenAbilities.Contains(randomAbility))
        //     {
        //         chosenAbilities.Add(randomAbility);
        //     }
        // }


    }
    public bool HasLevelUp()
    {
        if (IsLevelUp)
        {
            AudioManager.Instant.PlaySFX(CONTANST.powerup);
            IsLevelUp = false;
            // Player.Instance.activeWeapon.levelUpWeapon();
            return true;
        };
        return false;
    }

}
