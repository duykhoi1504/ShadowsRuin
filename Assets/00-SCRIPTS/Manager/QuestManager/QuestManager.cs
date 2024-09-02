using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class QuestManager : Singleton<QuestManager>
{
    [SerializeField] private List<Quest> quests;
    [SerializeField] private List<Quest> questValid;
    [SerializeField] private QuestItem questPrefab;
    [SerializeField] GameObject questPanel;
    public bool canOpen;


    [SerializeField] Transform parent;
    public int currentGoal;
    private void Start()
    {
        canOpen = false;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && canOpen)
        {
            questPanel.SetActive(true);
            LoadQuest();
        }
    }
    public void LoadQuest()
    {
        questValid.Clear(); // Xóa danh sách nhiệm vụ hợp lệ
         parent.Clear();
        int rand;

        // Đảm bảo rằng không vượt quá số lượng nhiệm vụ có sẵn
        int questCount = Mathf.Min(3, quests.Count);

        for (int i = 0; i < questCount; i++)
        {
            do
            {
                rand = Random.Range(0, quests.Count);
            } while (questValid.Contains(quests[rand]));

            questValid.Add(quests[rand]);
        }
        // foreach (Transform a in parent)
        // {
        //     Destroy(a.gameObject);
        // }
       
        foreach (var a in questValid)
        {
            QuestItem questItem = Instantiate(questPrefab, transform.position, Quaternion.identity, parent);
            questItem.ConfigQuestItem(a);
        }
    }
}