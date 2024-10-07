using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Objects/Ability/FireBall", order = 1)]
public class FireBall : Ability
{
    // Start is called before the first frame update
    [SerializeField] private FireBallParabol vfx;

    // public float coolDownTimer;
    public float speed;
    [SerializeField] float numBullet;

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
            SpawnFire();


        }
    }
    public void SpawnFire()
    {
        for (int i = 0; i < numBullet; i++)
        {
            FireBallParabol fx = Instantiate(vfx, Player.Instant.transform.position, Quaternion.identity);
            fx.Init(Player.Instant.transform.position, Player.Instant.Mouse, (a) => Destroy(a));
        }
        // Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // worldPoint.z = 0;
        // Vector2 dir = worldPoint - Player.Instant.transform.position;

        // fx.GetComponent<Rigidbody2D>().velocity = Player.Instant.currentDir.normalized * speed;
        // fx.transform.up= fx.GetComponent<Rigidbody2D>().velocity.normalized ;

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
