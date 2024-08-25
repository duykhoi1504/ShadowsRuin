using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Objects/Ability/FireBall", order = 1)]
public class FireBall : Ability
{
    // Start is called before the first frame update
    [SerializeField] private GameObject vfx;

    public float coolDownTimer;



    protected override void OnEnable()
    {
        base.OnEnable();

        coolDownTimer = 0f;
    }
    public override void Use()
    {

        if (coolDownTimer <= 0)
        {
            coolDownTimer = CoolDown;
            GameObject fx = Instantiate(vfx, Player.Instant.transform.position, Quaternion.identity);
            // Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // worldPoint.z = 0;
            // Vector2 dir = worldPoint - Player.Instant.transform.position;
            fx.GetComponent<Rigidbody2D>().velocity = Player.Instant.currentDir.normalized * 10f;
            Destroy(fx, Duration);

        }
    }

    public override void UpdateCoolDownTimer(float deltaTime)
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= deltaTime;
        }
    }

    public override void SetStatsForUpGrade()
    {
        throw new System.NotImplementedException();
    }

    // public override bool CanUseSkill()
    // {
    //     return false;   
    // }
}
