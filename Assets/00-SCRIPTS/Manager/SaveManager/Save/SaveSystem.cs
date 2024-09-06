using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

public class SaveSystem:Singleton<SaveSystem>
{
    [SerializeField] private PLayerData playerData;
    [SerializeField] private GameContentSO gameContentSO;
    private static string savePath = Application.dataPath + "/savefile.json";

    public PLayerData PlayerData { get => playerData; set => playerData = value; }

    // public static void Save<T>(T data)
    // {
    //     string json = JsonUtility.ToJson(data, true);
    //     File.WriteAllText(savePath, json);
    //     Debug.Log("Data saved to: " + savePath);
    // }

    // public static T Load<T>()
    // {
    //     if (File.Exists(savePath))
    //     {
    //         string json = File.ReadAllText(savePath);
    //         return JsonUtility.FromJson<T>(json);
    //     }
    //     else
    //     {
    //         Debug.LogWarning("Save file not found in " + savePath);
    //         return default; // Trả về giá trị mặc định của kiểu T
    //     }
    // }
    private void Start() {
        LoadData();
    }
    private void Update() {
        if(Input.GetKey(KeyCode.B)) {
            SaveData();
        }
        if(Input.GetKey(KeyCode.N)) {
            LoadData();
        }
    }
        public void LoadData()
    {
        if (!File.Exists(savePath))
        {
            File.WriteAllText(savePath, "");
            Debug.Log("file load");

        }
        string json = File.ReadAllText(savePath);
        PlayerData = JsonUtility.FromJson<PLayerData>(json);
    }
    public void SaveData()
    {
        playerData.diamond=gameContentSO.Diamond;
        playerData.itemList=InventoryManager.Instant.items;
        string json = JsonUtility.ToJson(PlayerData,true);
        File.WriteAllText(savePath, json);
        Debug.Log("file save");
    }
}
[System.Serializable]
public class PLayerData{
    public int diamond;
    public List<ScoreDetail> scores;
    public List<Item> itemList;


}
[System.Serializable]
public class ScoreDetail{
    public int score;
    public string time;
    public ScoreDetail(int _score,string _time){
        score=_score;
        time=_time;
    }
    }

