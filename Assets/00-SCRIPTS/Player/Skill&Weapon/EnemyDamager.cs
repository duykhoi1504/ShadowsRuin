using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] private Weapon weapon;
    [Header("ability")]
    [SerializeField] private Ability ability;
    [SerializeField] private float knockSpeed;

    public float KnockSpeed { get => knockSpeed; set => knockSpeed = value; }

    private void Start()
    {
        weapon = GetComponentInParent<Weapon>();

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            if (weapon != null)
            {
                Enemy enemy = other.GetComponent<Enemy>();
                float damageA = weapon.GetDamage(out bool isCriticalHit);
                enemy.TakeDamage(damageA, isCriticalHit, false);
            }
            else
            {
                other.GetComponent<Enemy>().knockSpeed = KnockSpeed;
                float damageA = !ability ? 100 : ability.Damage;
                bool isCriticalHit = false;
                if (Random.Range(0, 100) <= 50)
                {
                    isCriticalHit = true;

                    damageA = damageA * 2;
                }
                Enemy enemy = other.GetComponent<Enemy>();
                enemy.TakeDamage(damageA, isCriticalHit, true);
                // other.GetComponent<Enemy>().knockSpeed = 10f;

            }
        }
    }
}
