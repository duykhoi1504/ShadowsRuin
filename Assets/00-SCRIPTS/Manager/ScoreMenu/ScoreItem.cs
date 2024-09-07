using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ScoreDetail score;

    [SerializeField] private TextMeshProUGUI idScore;

    [SerializeField]private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    

    public ScoreDetail Score { get => score; set => score = value; }

 

    public void ConfigScoreItem(int id ,ScoreDetail _score){
        idScore.text=id.ToString();
        score=_score;
        scoreText.text=score.score.ToString();
        timeText.text=score.time;

    }
}
