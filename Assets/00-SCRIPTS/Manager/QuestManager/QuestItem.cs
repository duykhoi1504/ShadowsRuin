using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestItem : MonoBehaviour
{
    Quest quest;
    [SerializeField] bool isComplete = false;
    [SerializeField] bool isRecieved = false;
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI questGoal;
    [SerializeField] TextMeshProUGUI diamond;
    [SerializeField] Transform rewardUIParent;
    [SerializeField] GameObject rewardPrefab;


    [SerializeField]Button ClampButton;

    private void Start()
    {
        ClampButton=GetComponentInChildren<Button>(); 
        ClampButton.onClick.AddListener(() => Clamp());
        // ClampButton.enabled = false;
        // ClampButton.GetComponentInChildren<TextMeshProUGUI>().text = "UnComplete";
        setButton(false, "UnComplete", Color.white);

    }

    // Update is called once per frame
    void Update()
    {
        if (isComplete)
        {
            setButton(true, "Complete", Color.yellow);
        }
        if(isRecieved){
 setButton(false, "Recieved", Color.white);
        }
    }
    public void ConfigQuestItem(Quest _quest)
    {
        quest = _quest;
        name.text = quest.Name;
        description.text = quest.Desc;
        questGoal.text = QuestManager.Instant.currentGoal + "/" + $"{quest.QuestGoal.ToString()}";
        diamond.text = quest.Diamond.ToString();
        if(quest.Reward!=null){
            foreach(ItemReWard item in quest.Reward){
                GameObject rewardtoSpawn=Instantiate(rewardPrefab,transform.position,Quaternion.identity,rewardUIParent);
                rewardtoSpawn.GetComponentInChildren<TextMeshProUGUI>().text=item.quantity.ToString();
                rewardtoSpawn.GetComponentInChildren<Image>().sprite=item.item.image;

            }
        }
    }
    public void Clamp()
    {
        isRecieved=true;
       
        PlayerCoin.Instant.CurrenDiamond += quest.Diamond;
        if (quest.Reward != null)
        {
            foreach (ItemReWard a in quest.Reward)
            {
                InventoryManager.Instant.AddItem(a.item, a.quantity);
            }
        }
        
    }
    public void setButton(bool isActive, string status, Color color)
    {
        ClampButton.enabled = isActive;
        ClampButton.GetComponentInChildren<TextMeshProUGUI>().text = status;
        ClampButton.GetComponent<Image>().color = color;
    }
}
