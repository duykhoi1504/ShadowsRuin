using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    [Header("Elements info")]
    [SerializeField] Transform shootingPoint;
    // [SerializeField] float damage;
    [SerializeField] float shootSpeed;


   protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        AutoAim();
    }

    protected override void AutoAim()
    {
        Enemy enemyCloset = GetEnemyClosest();
        Vector2 targetUpVector = Vector3.up;


        if (enemyCloset != null)
        {
            targetUpVector = (enemyCloset.transform.position - transform.position).normalized;
            transform.up = targetUpVector;
            ManageShootingTimer();
            return;
        }
        transform.up = Vector3.Lerp(transform.up, targetUpVector, Time.deltaTime * aimLerp);
        // Quaternion newRotation = Quaternion.LookRotation(transform.forward, dir);
        // transform.rotation = newRotation;


    }
    private void ManageShootingTimer()
    {
        AttackTimer += Time.deltaTime;
        if (AttackTimer >= attackDelay)
        {
            AttackTimer = 0;
            Shoot();
        }
        
    }
    void Shoot()
    {
        PlayerBullet _bullet = ObjectPooling_Manager<PlayerBullet>.Instant.GetObject();
        // PlayerBullet _bullet = GameManager.Instance.playerbulletPool.GetObject();

        _bullet.transform.position = transform.position;
        _bullet.transform.rotation = transform.rotation;
        float damageA=GetDamage(out bool isCriticalHit);
        _bullet.Shoot(damageA,shootSpeed,transform.up,isCriticalHit);
         _bullet.gameObject.SetActive(true);
    }

   
}
