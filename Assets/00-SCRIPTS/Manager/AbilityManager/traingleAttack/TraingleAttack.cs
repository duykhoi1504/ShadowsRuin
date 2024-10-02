using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Objects/Ability/TraingleAttack", order = 1)]

public class TraingleAttack : Ability
{
    // Start is called before the first frame update
    [SerializeField] private GameObject vfx;

    // public float coolDownTimer;
    [SerializeField] private float distance;
    [SerializeField] private float speed;

    public float Distance { get => distance; set => distance = value; }
    public float Speed { get => speed; set => speed = value; }
    public int NumShots { get => numShots; set => numShots = value; }

    private int numShots; // Số lượng tia ban đầu
    protected override void OnEnable()
    {
        base.OnEnable();
        isPlaySFx = true;

        speed = abilityStats[level].value;
        coolDownTimer = 0f;
        SetStatsForUpGrade();
    }


    public override void Use()
    {
             if (isPlaySFx)
        {
            isPlaySFx = false;
            AudioManager.Instant.PlaySFX(CONTANST.block);
        }
        Vector3 playerDir = Player.Instant.currentDir;
        Vector3[] directions = new Vector3[NumShots];

        float angleOffset = 60f / (NumShots - 1); // Khoảng cách góc giữa các tia

        for (int i = 0; i < NumShots; i++)
        {
            float angle = (i - (NumShots - 1) / 2) * angleOffset; // Tính góc của mỗi tia
            directions[i] = Quaternion.Euler(0, 0, angle) * playerDir; // Tạo vector hướng của mỗi tia
        }


        if (coolDownTimer <= 0)
        {
            coolDownTimer = CoolDown;
            foreach (Vector3 dir in directions)
            {
                GameObject fx = Instantiate(vfx, Player.Instant.transform.position, Quaternion.identity);
                fx.GetComponent<Rigidbody2D>().velocity = dir * Speed;
                fx.transform.up = dir;
                Destroy(fx, Duration);
            }
        }
        ///==========================Giai thich==========================
        //       num=4
        // angle=60/3=20;
        // i=0 =>  (i-(num-1)/2) * angle
        // 	0-1.5  *20=-30
        // i=1 => 	1-1.5  *20=-10
        // i=2 => 	2-1.5  *20=10
        // i=3 => 	3-1.5  *20=30
        ///==============================================================
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
        NumShots = (int)abilityStats[level].value;

        if (vfx.GetComponent<EnemyDamager>() != null )
        {
            if(Level==0){}
            vfx.GetComponent<EnemyDamager>().KnockSpeed =0 ;

            if(Level >=1)
            vfx.GetComponent<EnemyDamager>().KnockSpeed =abilityStats[level].value ;
        }
    }
}
