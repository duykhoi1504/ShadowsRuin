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
    [SerializeField] Slider sliderXP;
    [SerializeField] TextMeshProUGUI text;
    void Start()
    {
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
            currentXP=0;
            level++;
            UpdateRequireXP();
        }
        UpdateGUI();
    }
}
