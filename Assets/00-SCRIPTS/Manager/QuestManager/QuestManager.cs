using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
public class QuestManager : Singleton<QuestManager>
{
    // [SerializeField] private List<Quest> quests;
    // [SerializeField] private List<Quest> questValid;
    [SerializeField] private QuestItem questPrefab;
    [SerializeField] GameObject questPanel;
    public bool canOpen;
    [SerializeField] Transform parent;

    [SerializeField] GameContentSO gameContentSO;

    public GameContentSO GameContentSO { get => gameContentSO; set => gameContentSO = value; }

    private void Start()
    {
        Enemy.OnPassAway += AddGoal;
        canOpen = false;
        LoadLastResetDate();
        CheckForReset();

    }
    private void OnDestroy()
    {
        Enemy.OnPassAway -= AddGoal;

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && canOpen)
        {
             AudioManager.Instant.PlaySFX(CONTANST.open);

            questPanel.SetActive(true);
            LoadQuest();
        }
    }

    public void LoadQuest()
    {

        parent.Clear();
        foreach (var a in GameContentSO.QuestValid)
        {
            QuestItem questItem = Instantiate(questPrefab, transform.position, Quaternion.identity, parent);
            questItem.ConfigQuestItem(a);
        }
    }

    private void CheckForReset()
    {
        DateTime currentDate = DateTime.Now;

        // Construct the reset time for today
        DateTime resetTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day,
                                          GameContentSO.ResetHour, GameContentSO.ResetMinute, GameContentSO.ResetSecond);
        Debug.Log($"Current Date: {currentDate}");
        Debug.Log($"Reset Time: {resetTime}");
        Debug.Log($"Last Reset Date: {GameContentSO.LastResetDate}");
        // Check if today is Monday and the current time is past the reset time
        if (currentDate.DayOfWeek == DayOfWeek.Thursday &&
            currentDate >= resetTime &&
            GameContentSO.LastResetDate.Date != currentDate.Date)
        {
            ResetQuests();
            GameContentSO.LastResetDate = currentDate.Date; // Update the last reset date
            SaveLastResetDate();
        }
    }
    [Button]
    private void ResetQuests()
    {
        foreach (var a in GameContentSO.QuestValid)
        {

            a.IsComplete = false;
            a.IsRecieved = false;
        }
        //xoa tong so quai giet dc trong tuan
        GameContentSO.CurrentGoal = 0;

        GameContentSO.QuestValid.Clear(); // Xóa danh sách nhiệm vụ hợp lệ


        int questCount = Mathf.Min(3, GameContentSO.Quests.Count);
        List<Quest> tempQuestList = new List<Quest>(GameContentSO.Quests);

        for (int i = 0; i < questCount; i++)
        {
            int rand = Random.Range(0, tempQuestList.Count);
            GameContentSO.QuestValid.Add(tempQuestList[rand]);
            tempQuestList.RemoveAt(rand); // Remove the selected quest from the temporary list
        }


        Debug.Log("Danh sách nhiệm vụ đã được reset vào " + DateTime.Now);
    }
    private void SaveLastResetDate()
    {
        PlayerPrefs.SetString("LastResetDate", GameContentSO.LastResetDate.ToString("o")); // Only date
        PlayerPrefs.Save();
    }

    private void LoadLastResetDate()
    {
        // if (PlayerPrefs.HasKey("LastResetDate"))
        // {
        //     GameContentSO.LastResetDate = DateTime.Parse(PlayerPrefs.GetString("LastResetDate"));
        // }
        // else
        // {
        //     GameContentSO.LastResetDate = DateTime.MinValue; // Set to current date if not found
        // }

        string dateString = PlayerPrefs.GetString("LastResetDate", DateTime.MinValue.ToString("o"));
        GameContentSO.LastResetDate = DateTime.Parse(dateString, null, System.Globalization.DateTimeStyles.RoundtripKind);
    }
    private void AddGoal(Vector2 enemyPos)
    {
        gameContentSO.CurrentGoal += 1;
    }
}