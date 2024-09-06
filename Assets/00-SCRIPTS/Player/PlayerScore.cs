using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerScore : Singleton<PlayerScore>
{
    private int score;

    public int Score { get => score; set => score = value; }

    private void Start() {
    UIManager.Instant.UpdateScoreGUI(Score);
    Score=0;
}

private void Update() {
        UIManager.Instant.UpdateScoreGUI(Score);
    
}
    public void AddScore(int _num){
        
        Score+=_num;
    }
    public void ResetScore(){
        Score=0;
    }
}
