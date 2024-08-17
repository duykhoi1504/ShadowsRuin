using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class PlayerLevel : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private int requireXP;
     [SerializeField]private int currentXP;
     [SerializeField]private int level;
     [SerializeField]private bool isLevelUp;
    [SerializeField] Slider sliderXP;
    [SerializeField] TextMeshProUGUI text;
    void Start()
    {   
        isLevelUp=false;
        Exp.onCollected+=UpdateCurrentXP;
        UpdateRequireXP();
        UpdateGUI();
    }
    private void OnDestroy() {
        Exp.onCollected-=UpdateCurrentXP;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateRequireXP(){
        requireXP=(level+1)*5;
    }
    void UpdateGUI(){
        sliderXP.value=(float)currentXP/ requireXP;
        text.text="level "+(level+1);
    }
   private void UpdateCurrentXP(Exp exp){
        currentXP++;
        if(currentXP>=requireXP){
            isLevelUp=true;
            currentXP=0;
            level++;
            UpdateRequireXP();
            // GameManager.Instance.ChangeState(GameState.SHOP);
        }
        UIManager.Instance.levelUpButon[0].UpdateButtonDisplay(Player.Instance.assignedwWeapons[0].GetComponent<Weapon>());
        UIManager.Instance.levelUpButon[1].UpdateButtonDisplay(Player.Instance.unAssignedWeapons[0].GetComponent<Weapon>());
        UIManager.Instance.levelUpButon[2].UpdateButtonDisplay(Player.Instance.unAssignedWeapons[1].GetComponent<Weapon>());

        UpdateGUI();

    }
    public bool HasLevelUp(){
        if(isLevelUp){
            isLevelUp=false;
            Player.Instance.activeWeapon.levelUpWeapon();
            return true;
        };
        return false;
    }

}
