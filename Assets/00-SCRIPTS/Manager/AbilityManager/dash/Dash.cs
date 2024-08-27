using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Objects/Ability/Dash", order = 1)]
public class Dash : Ability
{
    // Start is called before the first frame update
    [SerializeField] private GameObject vfx;

    [SerializeField] private float dashSpeed;
    public bool isDashing = false;
    public float coolDownTimer;

    protected override void OnEnable()
    {
        base.OnEnable();
        // dashSpeed=2f;
        coolDownTimer = 0f;
        SetStatsForUpGrade();


    }
    //  protected void OnDestroy()
    // {

    //     // dashSpeed=2f;
    //     coolDownTimer = 0f;

    // }
    public override void Use()
    {
        if (coolDownTimer <= 0)
        {
            coolDownTimer = CoolDown;

            if (level > 0)
            {
                GameObject fx = Instantiate(vfx, Player.Instant.transform.position, Quaternion.identity);
                Destroy(fx, Duration);
            }


            // Player.Instant.stateMachine.ChangeState(Player.Instant.dashState);
            Player.Instant.StartCoroutine(DashCoroutine());
            // Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // worldPoint.z = 0;
            // Vector2 dir=worldPoint-Player.Instant.transform.position;
            //  Player.Instant.rb.velocity = Player.Instant.currentDir.normalized * 10f;
            // Player.Instant.rb.AddForce(Player.Instant.currentDir.normalized * dashSpeed);
            // Player.Instant.stateMachine.ChangeState(Player.Instant.idleState);

            //  Player.Instant.transform.Translate(Player.Instant.currentDir * dashSpeed * Time.deltaTime);
        }
    }
    public override void UpdateCoolDownTimer(float deltaTime)
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= deltaTime;

        }

    }
    private IEnumerator DashCoroutine()
    {


        // Áp dụng lực dash
        Player.Instant.transform.Translate(Player.Instant.currentDir * dashSpeed);
        // Chờ một khoảng thời gian để hoàn thành Dash
        yield return new WaitForSeconds(Duration);

    }
    public override void SetStatsForUpGrade()
    {
        if (level >= abilityStats.Count)
        {
            level = abilityStats.Count - 1;
        }
        dashSpeed = (float)abilityStats[level].value;
    }
    // public override bool CanUseSkill()
    // {
    //     if (coolDownTimer <= 0)
    //     {
    //         coolDownTimer = CoolDown;
    //         return true;
    //     }
    //     else
    //         return false;
    // }
}
