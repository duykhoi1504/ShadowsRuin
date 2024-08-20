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
        SetStats();
        sp = GetComponentInChildren<SpriteRenderer>();


    }
    private void Update()
    {
        Debug.Log(stats.Count + " EarthquakeAbility");
        //hoac 
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            sp.sprite = earthquakeSprite;
            Attack();
            lastAttackTime = Time.time;
            StartCoroutine(EarthquakeFX(attackDelay));
            // LeanTween

        }

        if (isStatsUpdate)
        {
            SetStats();
            isStatsUpdate = false;
        }

    }
    public override void SetStats()
    {

            damage = stats[levelWeapon].damage;
            range = stats[levelWeapon].range;
            // spinSpeed = stats[levelWeapon].speed;
            // attackDelay = stats[levelWeapon].duration;
            attackDelay = stats[levelWeapon].attackDelay;
        
    }

    private IEnumerator EarthquakeFX(float x)
    {
        sp.sprite = earthquakeSprite;
        // Scale lên (9, 9, 9)
        LeanTween.scale(gameObject, new Vector3(range, range, range), x).setEase(LeanTweenType.easeOutBounce);

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
                enemy.TakeDamage(damageA, isCriticalHit, true);
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
