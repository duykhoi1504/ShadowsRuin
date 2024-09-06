using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ScoreDetail score;

    [SerializeField]private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;

    public ScoreDetail Score { get => score; set => score = value; }

 

    public void ConfigScoreItem(ScoreDetail _score){
        score=_score;
        scoreText.text=score.score.ToString();
        timeText.text=score.time;

    }
}
