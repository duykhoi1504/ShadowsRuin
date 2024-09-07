using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMenuManager : Singleton<ScoreMenuManager>
{
    [SerializeField] List<ScoreDetail> scores;
    
    [SerializeField] ScoreItem scoreItemPrefab;
    [SerializeField] Transform parent;

    // void Start()
    // {
    //     if (SaveSystem.Instant)
    //         scores = SaveSystem.Instant.PlayerData.scores;

    // }

    // Update is called once per frame
    void Update()
    {

    }
    public void ListScore()
    {
         if (SaveSystem.Instant)
            scores = SaveSystem.Instant.PlayerData.scores;

        parent.Clear();
        for (int i=0; i<scores.Count;i++){
                ScoreItem pre = Instantiate(scoreItemPrefab, transform.position, Quaternion.identity, parent);
                pre.ConfigScoreItem(i+1,scores[i]);
        }
        
    }
}
