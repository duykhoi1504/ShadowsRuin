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

    void Start()
    {
        isLevelUp = false;
        Exp.onCollected += UpdateCurrentXP;
        UpdateRequireXP();
        UIManager.Instance.UpdateXPGUI( currentXP, requireXP, level);
    }
    private void OnDestroy()
    {
        Exp.onCollected -= UpdateCurrentXP;

    }
    // Update is called once per frame
    void Update()
    {

    }
    void UpdateRequireXP()
    {
        requireXP = (level + 1) * 5;
    }
    // void UpdateGUI()
    // {
    //     sliderXP.value = (float)currentXP / requireXP;
    //     text.text = "level " + (level + 1);
    // }
    private void UpdateCurrentXP(Exp exp)
    {
        currentXP++;
        if (currentXP >= requireXP)
        {
            // Debug.Log(exp.gameObject.name);
            isLevelUp = true;
            currentXP = 0;
            level++;
            UpdateRequireXP();
            // GameManager.Instance.ChangeState(GameState.SHOP);

        }
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

         UIManager.Instance.UpdateXPGUI( currentXP, requireXP, level);

    }
    public bool HasLevelUp()
    {
        if (isLevelUp)
        {
            isLevelUp = false;
            // Player.Instance.activeWeapon.levelUpWeapon();
            return true;
        };
        return false;
    }

}
