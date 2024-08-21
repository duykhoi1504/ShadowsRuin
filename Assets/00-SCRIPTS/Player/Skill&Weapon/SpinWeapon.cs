using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpinWeapon : Weapon
{
    // Start is called before the first frame update
    [SerializeField] protected Transform HitDetectTransform;
    private float spinSpeed = 5f;
    [SerializeField] BoxCollider2D cd;
    private float lifeTime = 2f;
    private float timeScale;
    Vector3 targetSize;
    bool isHide;
    public Transform holder;
    public GameObject spinWeaponToSpawn;

    
    
    // private float lastAttackTime;
    // private float attackCooldown = 0.1f; // Thay đổi thời gian này cho phù hợp
    void Start()
    {
        SetStats();
        // UIManager.Instance.levelUpButon[0].UpdateButtonDisplay(this);

        isHide = false;
        // this.gameObject.SetActive(true);
        targetSize = this.transform.localScale;
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {



        //    this.transform.Rotate(0,0,spinSpeed*Time.deltaTime);
        //hoac 
        // if (Time.time >= lastAttackTime + attackCooldown)
        // {
        //     Attack();
        //     lastAttackTime = Time.time;
        // }
        //xoay

        this.transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z - (spinSpeed * Time.deltaTime));
        //thu nho
        if (isHide)
        {
            this.transform.localScale = Vector3.MoveTowards(this.transform.localScale, targetSize, 1.5f * Time.deltaTime);
        }
        //phong to
        else
            this.transform.localScale = Vector3.MoveTowards(this.transform.localScale, Vector3.zero, 1.5f * Time.deltaTime);
        timeScale -= Time.deltaTime;
        if (timeScale < 0)
        {
            isHide = !isHide;

            timeScale = isHide ? lifeTime : attackDelay;


        }

        if (isStatsUpdate)
        {
            SetStats();
            isStatsUpdate = false;
            for (int i = 0; i < stats[levelWeapon].amount; i++)
            {
                float rot = (360f / stats[levelWeapon].amount) * i;
                GameObject spin = Instantiate(spinWeaponToSpawn, this.transform.position, Quaternion.Euler(0f, 0f, rot), holder);

            }
        }
    }
    public override void SetStats()
    {
        if (levelWeapon < stats.Count - 1)
        {
            damage = stats[levelWeapon].damage;
            range = stats[levelWeapon].range;
            spinSpeed = stats[levelWeapon].speed;
            lifeTime = stats[levelWeapon].duration;
            attackDelay = stats[levelWeapon].attackDelay;
        }
    }

    // public void Attack()
    // {
    //     Collider2D[] enemies = Physics2D.OverlapCircleAll(HitDetectTransform.position, range, enemyMask);

    //     foreach (var hit in enemies)
    //     {
    //         Enemy enemy = hit.GetComponent<Enemy>();
    //         if (enemy != null)
    //         {
    //             float damageA = GetDamage(out bool isCriticalHit);
    //             enemy.TakeDamage(damageA, isCriticalHit,false);
    //         }
    //     }
    // }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.GetComponent<Enemy>() != null)
    //     {
    //         float damageA = GetDamage(out bool isCriticalHit);
    //         other.gameObject.GetComponent<Enemy>().TakeDamage(damageA, isCriticalHit);
    //     }
    // }
    protected override void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(HitDetectTransform.transform.position, range);
    }
}

