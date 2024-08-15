using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class DropManager :ObjectPoolingX<DroppableBase>
{
    // Start is called before the first frame update
    [SerializeField] private Exp expPrefab;
    [SerializeField] private Coin coinPrefab;
    // ObjectPoolingX<DroppableBase> pool;



    private void Awake()
    {
        Enemy.OnPassAway += EnemyPassAwayCallBack;
    }
    private void OnDestroy()
    {
        Enemy.OnPassAway += EnemyPassAwayCallBack;

    }


    private void EnemyPassAwayCallBack(Vector2 enemyPos)
    {
        bool randomDrops = Random.Range(0, 101) <= 20;
        DroppableBase droppable = randomDrops ? GetObjectType(coinPrefab) :GetObjectType(expPrefab);
        // Instantiate(droppable,enemyPos,quaternion.identity,transform);
        if(droppable==null)return;
        droppable.transform.position = enemyPos;
        droppable.transform.rotation = quaternion.identity;
       
        droppable.gameObject.SetActive(true);
    }

}
