using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Objects/Ability/FireBall", order = 1)]
public class FireBall : Ability
{
    // Start is called before the first frame update
    [SerializeField] private GameObject vfx;

    // public float coolDownTimer;
    public float speed;


    protected override void OnEnable()
    {
        base.OnEnable();
        isPlaySFx = true;
        coolDownTimer = 0f;
    }

    public override void Use()
    {

        if (isPlaySFx)
        {
            isPlaySFx = false;
            AudioManager.Instant.PlaySFX(CONTANST.fire);
        }
        if (coolDownTimer <= 0)
        {
            coolDownTimer = CoolDown;
            GameObject fx = Instantiate(vfx, Player.Instant.transform.position, Quaternion.identity);
            // Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // worldPoint.z = 0;
            // Vector2 dir = worldPoint - Player.Instant.transform.position;

            fx.GetComponent<Rigidbody2D>().velocity = Player.Instant.currentDir.normalized * speed;
            fx.transform.up= fx.GetComponent<Rigidbody2D>().velocity.normalized ;
            Destroy(fx, Duration);

        }
    }

    public override void UpdateCoolDownTimer(float deltaTime)
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= deltaTime;
        }
        if (coolDownTimer <= 0)
        {
            isPlaySFx = true;
        }


    }

    public override void SetStatsForUpGrade()
    {
        if (level >= abilityStats.Count)
        {
            level = abilityStats.Count - 1;
        }
        speed = abilityStats[level].value;
    }

    // public override bool CanUseSkill()
    // {
    //     return false;   
    // }
}
