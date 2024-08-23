using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{

    Weapon weapon;
    private void Start()
    {
        weapon = GetComponentInParent<Weapon>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            if (weapon != weapon)
            {
                Enemy enemy = other.GetComponent<Enemy>();
                float damageA = weapon.GetDamage(out bool isCriticalHit);
                enemy.TakeDamage(damageA, isCriticalHit, false);
            }
            else
            {
                Enemy enemy = other.GetComponent<Enemy>();
                enemy.TakeDamage(20, true, false);
            }
        }
    }
}
