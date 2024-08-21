using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, ISkill
{
    // Start is called before the first frame update


    // [Header("Elements info")]
    // // [SerializeField] protected Transform hitCheck;
    // protected SpriteRenderer sprite;

    [Header("Setting info")]
    [SerializeField] protected float range;
    [SerializeField] protected LayerMask enemyMask;



    [Header("Attack info")]
    protected float AttackTimer;
    [SerializeField] protected float attackDelay;

    [SerializeField] protected float damage;
    [Header("Animations info")]
    // [SerializeField] protected float aimLerp;
    [Header("Upgrade info")]

    public List<WeaponStats> stats;
    public int levelWeapon;
    [SerializeField] protected bool isStatsUpdate;
    public Sprite icon;

    public void levelUpWeapon()
    {
        if (levelWeapon < stats.Count - 1)
        {
            levelWeapon++;
            isStatsUpdate = true;


            if (levelWeapon >= stats.Count - 1)
            {
                PlayerManager.Instance.fullyLevelWeaon.Add(this);
                PlayerManager.Instance.assignedwWeapons.Remove(this);

            }
        }
    }


    protected virtual void AutoAim() { }
    protected Enemy GetEnemyClosest()
    {
        Enemy closetTarget = null;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, enemyMask);


        // foreach (var enemy in enemies)
        //     Debug.Log(enemy.name);

        if (enemies.Length <= 0)
            return null;

        float minDistancel = range;

        foreach (var hit in enemies)
        {
            Enemy closetTargetChecked = hit.GetComponent<Enemy>();
            if (closetTargetChecked != null)
            {
                // float closetTargetDistance1 = (closetTargetChecked.transform.position - transform.position).magnitude;

                float closetTargetDistance = Vector2.Distance(closetTargetChecked.transform.position, transform.position);


                if (closetTargetDistance < minDistancel)
                {
                    closetTarget = closetTargetChecked;
                    minDistancel = closetTargetDistance;

                }
            }
        }
        return closetTarget;
    }

    //Từ khóa out cho phép một phương thức trả về nhiều giá trị thông qua các tham số.
    //không cần phải tạo thêm biến isCritical
    //Khi gọi phương thức GetDamage(), ngoài việc nhận về giá trị float (damage), bạn cũng có thể nhận về giá trị bool (isCriticalHit) thông qua tham số out.
    public float GetDamage(out bool isCriticalHit)
    {
        isCriticalHit = false;
        if (Random.Range(0, 100) <= 50)
        {
            isCriticalHit = true;
            return damage * 2;
        }
        return damage;
    }

    protected virtual void OnDrawGizmos()
    {
        // Vẽ một đường tròn với bán kính 2 tại vị trí của game object
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
        // if (hitCheck == null)
        //     return;
        // Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(hitCheck.transform.position, hitRadius);

    }
    public virtual void SetStats() { }

}
[System.Serializable]
public class WeaponStats
{
    public float speed, damage, range, attackDelay, duration, amount;
    public string upgradeText;
}
