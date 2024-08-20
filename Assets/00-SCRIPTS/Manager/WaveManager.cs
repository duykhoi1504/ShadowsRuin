using System.Collections;
using System.Collections.Generic;

using NaughtyAttributes;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class WaveManager : MonoBehaviour
{
    [SerializeField] private float distanceRanPos = 15f;

    // public float timeToSpawn;
    private float spawnCounter;
    private int currentWave;
    private float waveCounter;
    public List<Wave> waves = new List<Wave>();
    public List<GameObject> spawnEnemies = new List<GameObject>();

    void Start()
    {

        currentWave = -1;
        GoToNextWave();
    }

    // Update is called once per frame
    void Update()
    {
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