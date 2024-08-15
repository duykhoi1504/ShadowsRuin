using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RangeEnemy : Enemy
{
    [SerializeField] EnemyBullet bullet;

//cách 1 objectpooling
    // public List<EnemyBullet> bulletList = new List<EnemyBullet>();
//cach 2 dung script ObjectPooling
    // ObjectPooling<EnemyBullet> bulletPool;

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        // bulletPool = new ObjectPooling<EnemyBullet>(bullet, 3, transform);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        if (getDistanceEtoP() < attackRadious)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + getEnemyDir() * 5);
        }
    }
    // [NaughtyAttributes.Button]
    private void Shooting()
    {
       
        EnemyBullet _bullet = ObjectPooling_Manager<EnemyBullet>.Instant.GetObject();
        // EnemyBullet _bullet = GameManager.Instance.bulletPool.GetObject();

        _bullet.transform.position = transform.position;
        _bullet.transform.rotation = transform.rotation;
        _bullet.shoot(attackDamage, getEnemyDir());
         _bullet.gameObject.SetActive(true);
        ////=======================================
        //  EnemyBullet _bullet = bulletPool.GetObject();
        // _bullet.transform.position = transform.position;
        // _bullet.transform.rotation = transform.rotation;
        // _bullet.shoot(attackDamage, getEnemyDir());
        ////=======================================
        // EnemyBullet _bullet = GetObject(bullet, transform);
        // _bullet.gameObject.transform.position = transform.position;
        // _bullet.gameObject.transform.rotation = transform.rotation;
        // _bullet.gameObject.SetActive(true);
        // _bullet.shoot(attackDamage, getEnemyDir());
        
    }
    public override void attack()
    {
        Shooting();
    }

    //cách 1 objectpooling

    // public EnemyBullet GetObject(EnemyBullet gob, Transform _transform)
    // {
    //     foreach (var g in bulletList)
    //     {
    //         if (g.gameObject.activeSelf)
    //         {
    //             continue;

    //         }
    //         return g;
    //     }
    //     EnemyBullet g2 = Instantiate(gob, _transform.position, quaternion.identity);
    //     bulletList.Add(g2);
    //     return g2;
    // }
}
