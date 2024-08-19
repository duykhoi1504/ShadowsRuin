using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeAbility : Weapon
{



    private float lastAttackTime;
    private float attackCooldown = 1f; // Thay đổi thời gian này cho phù hợp
    [SerializeField] SpriteRenderer sp;
    // [SerializeField ]Sprite spriteOrigin;
    [SerializeField] Sprite earthquakeSprite;
    [SerializeField] protected Transform HitDetectTransform;

    private void Start()
    {
        sp = GetComponentInChildren<SpriteRenderer>();


    }
    private void Update()
    {
        //hoac 
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            sp.sprite = earthquakeSprite;
            Attack();
            lastAttackTime = Time.time;
            StartCoroutine(EarthquakeFX(.5f));
            // LeanTween

        }
    }

    private IEnumerator EarthquakeFX(float x)
    {
        sp.sprite = earthquakeSprite;
           // Scale lên (9, 9, 9)
    LeanTween.scale(gameObject, new Vector3(10, 10, 10), x).setEase(LeanTweenType.easeOutBounce);

        yield return new WaitForSeconds(x);
           LeanTween.scale(gameObject, Vector3.zero, x).setEase(LeanTweenType.easeInBounce);
        sp.sprite = null;


    }
    public void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(HitDetectTransform.position, range, enemyMask);

        foreach (var hit in enemies)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                float damageA = GetDamage(out bool isCriticalHit);
                enemy.TakeDamage(damageA, isCriticalHit);
            }
        }

    }
    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.gameObject.GetComponent<Enemy>()!=null){
    //          float damageA = GetDamage(out bool isCriticalHit);
    //         other.gameObject.GetComponent<Enemy>().TakeDamage(damageA, isCriticalHit);
    //     }
    // }
    protected override void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(HitDetectTransform.transform.position, range);
    }
}
