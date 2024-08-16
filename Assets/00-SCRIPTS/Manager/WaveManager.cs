using System.Collections;
using System.Collections.Generic;

using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class WaveManager : MonoBehaviour
{
    public float timeToSpawn;
    private float spawnCounter;
    private int currentWave;
    private float waveCounter;
public List<Wave> waves= new List<Wave>();
public List<GameObject> spawnEnemies= new List<GameObject>();


    void Start()
    {
            // spawnCounter=timeToSpawn;
            currentWave=-1;
            GoToNextWave();
    }

    // Update is called once per frame
    void Update()
    {
            if(Player.Instance.gameObject.activeSelf){
                if(currentWave<waves.Count){
                    waveCounter-=Time.deltaTime;
                    if(waveCounter <= 0){
                        GoToNextWave();
                    }
                    spawnCounter-=Time.deltaTime;
                    if(spawnCounter<=0){
                        spawnCounter=waves[currentWave].timeBeTweeenSpawns;
                        GameObject newEnemy=Instantiate(waves[currentWave].enemyPrefab,GetRandomPos(),Quaternion.identity);
                        spawnEnemies.Add(newEnemy);
                    }
                }
            }
    }

void GoToNextWave(){
    currentWave ++;
    if(currentWave>=waves.Count){
        currentWave=waves.Count-1;
    }
    waveCounter=waves[currentWave].waveLenght;
    spawnCounter=waves[currentWave].timeBeTweeenSpawns;
}
    private Vector2 GetRandomPos()
    {
        return (Vector2)Player.Instance.transform.position + Random.insideUnitCircle * 20f;
    }
}
[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public float waveLenght = 10f;
    public float timeBeTweeenSpawns = 1f;
}