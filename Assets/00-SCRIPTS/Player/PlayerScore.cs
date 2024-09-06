using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SocialPlatforms.Impl;
using System.Linq;
public class PlayerScore : Singleton<PlayerScore>
{
    [SerializeField] private int score;

    public int Score { get => score; set => score = value; }

    private void Start()
    {
    
        ResetScore();
        UIManager.Instant.UpdateScoreGUI(Score);
    }

    private void Update()
    {
        UIManager.Instant.UpdateScoreGUI(Score);
           
    }
    public void AddScore(int _num)
    {

        Score += _num;
    }
    public void ResetScore()
    {
        Score = 0;
    }
 public void AddHighScore(string time)
{
    // Ensure scores is initialized
    List<ScoreDetail> scores = SaveSystem.Instant.PlayerData.scores ?? new List<ScoreDetail>();

    // Check if the new score is higher than the max score in the list
    if (scores.Count == 0 || score > scores.Max(s => s.score))
    {
        ScoreDetail newScore = new ScoreDetail(score, time);
        scores.Add(newScore);  // Add the new score to the list
        
        SaveSystem.Instant.PlayerData.scores = scores; // Update PlayerData
        SaveSystem.Instant.SaveData();  // Save the updated data
    }
}
    // public void SaveScore(int score)
    // {
    //     PlayerPrefs.SetInt("PlayerScore", score);
    //     PlayerPrefs.Save(); // Lưu các thay đổi
    // }
    // public int LoadScore()
    // {
    //     return PlayerPrefs.GetInt("PlayerScore", 0); // Giá trị mặc định là 0 nếu không tìm thấy
    // }
}
