using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpinWeapon : Weapon
{
    // Start is called before the first frame update
    private float spinSpeed = 5f;
    [SerializeField] BoxCollider2D cd;
    private float lifeTime = 2f;
    private float timeScale;
    Vector3 targetSize;
    bool isHide;
    void Start()
    {
        // SetStats();
        // UIManager.Instance.levelUpButon[0].UpdateButtonDisplay(this);

        isHide = false;
        this.gameObject.SetActive(true);
        targetSize = this.transform.localScale;
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        //    this.transform.Rotate(0,0,spinSpeed*Time.deltaTime);
        //hoac 
        this.transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z - (spinSpeed * Time.deltaTime));
        if (isHide)
        {
            this.transform.localScale = Vector3.MoveTowards(this.transform.localScale, targetSize, 1.5f * Time.deltaTime);
        }
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
        }
    }
    private void SetStats()
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            float damageA = GetDamage(out bool isCriticalHit);
            other.gameObject.GetComponent<Enemy>().TakeDamage(damageA, isCriticalHit);
        }
    }

}

