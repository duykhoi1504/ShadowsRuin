
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class WaveManager : Singleton<WaveManager>
{
    [SerializeField] private float distanceRanPos = 15f;

    // public float timeToSpawn;
    private float spawnCounter;
    private int currentWave;
    private float waveCounter;
    public List<Wave> waves = new List<Wave>();
    public List<GameObject> spawnEnemies = new List<GameObject>();
    [Header("Timer info")]

    public float gameTimer;
    public Action onPlayerLevelUp;

    void Start()
    {

        currentWave = -1;
        GoToNextWave();
        // AbilityManager.Instant.ListAbilitysUse();
    }

    // Update is called once per frame
    void Update()
    {
        WaveComplete();
        
        if (GameManager.Instant.currentState == GameState.GAMEPLAY)
        {
            gameTimer += Time.deltaTime;
            updateTimer(gameTimer);
        }
        //set game timer text

        /////////////////////

        if (!Player.Instant.gameObject.activeSelf) return;

        if (currentWave < waves.Count)
        {
            waveCounter -= Time.deltaTime;
            if (waveCounter <= 0)
            {
                GoToNextWave();
            }
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                spawnCounter = waves[currentWave].timeBeTweeenSpawns;
                GameObject newEnemy = Instantiate(waves[currentWave].enemyPrefab, GetRandomPos(), Quaternion.identity, transform);
                spawnEnemies.Add(newEnemy);
            }
        }
        // GameManager.Instance.WaveCompleteCallBack();

    }
    public void WaveComplete()
    {
        if (Player.Instant.HasLevelUp())
        {
            GameManager.Instant.ChangeState(GameState.SHOP);
            UIManager.Instant.ShopContainer.SetActive(true);
            onPlayerLevelUp?.Invoke();


            // PlayerStatsManager.Instant.SetStatsRandButton();
            // PlayerWeaponManager.Instant.SetRandomCard();
        }
    }
    public void updateTimer(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60f);
        //chia lay du time= 60 % 60 du 0
        float seconds = Mathf.FloorToInt(time % 60f);

        GameManager.Instant.gameTimerText.text = minutes.ToString() + ":" + seconds.ToString();
    }
    public void endLevel()
    {
        float minutes = Mathf.FloorToInt(gameTimer / 60f);
        //chia lay du time= 60 % 60 du 0
        float seconds = Mathf.FloorToInt(gameTimer % 60f);
        GameManager.Instant.timeSurvire.text = minutes.ToString() + " mins " + seconds.ToString() + " secs";
    }
    public string TimeToString()
    {
        float minutes = Mathf.FloorToInt(gameTimer / 60f);
        //chia lay du time= 60 % 60 du 0
        float seconds = Mathf.FloorToInt(gameTimer % 60f);

        return minutes.ToString() + " mins " + seconds.ToString() + " secs";
    }
    void GoToNextWave()
    {
        currentWave++;
        if (currentWave >= waves.Count)
        {
            currentWave = waves.Count - 1;
        }
        waveCounter = waves[currentWave].waveLenght;
        spawnCounter = waves[currentWave].timeBeTweeenSpawns;
    }
    private Vector2 GetRandomPos()
    {
        return (Vector2)Player.Instant.transform.position + Random.insideUnitCircle * distanceRanPos;
    }
}



[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public float waveLenght = 10f;
    public float timeBeTweeenSpawns = 1f;
}