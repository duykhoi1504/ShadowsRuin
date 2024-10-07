
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

[System.Serializable]
public class Wave
{
    public Enemy enemyPrefab;
    public float waveLenght = 10f;
    public float timeBeTweeenSpawns = 1f;
}

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
    EnemyPool enemyPool;
    public float gameTimer;
    public Action onPlayerLevelUp;

    void Start()
    {
        enemyPool = FindObjectOfType<EnemyPool>(); 
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
                // GameObject newEnemy = Instantiate(waves[currentWave].enemyPrefab, GetRandomPos(), Quaternion.identity, transform);
                // spawnEnemies.Add(newEnemy);
            // SpawnE(waves[currentWave].enemyPrefab);
                 Enemy enemy = enemyPool.GetObjectType(waves[currentWave].enemyPrefab);
            if (enemy == null)
    {
        Debug.LogError("Enemy is null! Check if the enemy prefab is correctly assigned in the wave configuration.");
        return;
    }
        enemy.transform.position = GetRandomPos();
        enemy.transform.rotation = Quaternion.identity;
        enemy.gameObject.SetActive(true);
            }
        }
        // GameManager.Instance.WaveCompleteCallBack();

    }
    private void SpawnE(Enemy _enemy){
    //      Enemy enemy = enemyPool.GetObjectType(_enemy);
    //         if (enemy == null)
    // {
    //     Debug.LogError("Enemy is null! Check if the enemy prefab is correctly assigned in the wave configuration.");
    //     return;
    // }
    //     enemy.transform.position = GetRandomPos();
    //     enemy.transform.rotation = Quaternion.identity;
    //     enemy.gameObject.SetActive(true);
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
    private Vector2 GetRandomPos()
    {
        return (Vector2)Player.Instant.transform.position + Random.insideUnitCircle * distanceRanPos;
    }
}



