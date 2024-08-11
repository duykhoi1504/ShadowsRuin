using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RangeEnemy : Enemy
{
    // Start is called before the first frame update
    [SerializeField] EnemyBullet bullet;
 

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
   protected override void Update()
    {
        base.Update();

    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        if(getDistanceEtoP()<attackRadious){
        Gizmos.color=Color.white;
        Gizmos.DrawLine(transform.position,(Vector2)transform.position+getEnemyDir()*5);
        }
    }
    [NaughtyAttributes.Button]
    private void Shooting(){
        EnemyBullet _bullet=Instantiate(bullet,this.transform.position,quaternion.identity);
        // _bullet.transform.up=getEnemyDir();
        // _bullet.GetComponent<Rigidbody2D>().velocity=getEnemyDir()*bulletSpeed;
        // Destroy(_bullet,2f);
        _bullet.shoot(attackDamage,getEnemyDir());
    }
    public override void attack(){
        Shooting();
    }
}
