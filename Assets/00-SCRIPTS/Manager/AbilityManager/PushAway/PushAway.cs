using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Objects/Ability/PushAway", order = 1)]

public class PushAway : Ability
{
    // Start is called before the first frame update
    [SerializeField] private GameObject vfx;

    public float coolDownTimer;
    [SerializeField] private float scaleBoom;

    public float ScaleBoom { get => scaleBoom; set => scaleBoom = value; }

    protected override void OnEnable()
    {
         base.OnEnable();
        coolDownTimer = 0f;
         Time.timeScale=1f;
         SetStatsForUpGrade();
    }
    public override void Use()
    {
       
        if (coolDownTimer <= 0)
        {
            coolDownTimer = CoolDown;
            Time.timeScale=0.5f;
            CameraShake.Instant.beginShake();
            GameObject fx = Instantiate(vfx, Player.Instant.transform.position, Quaternion.identity);
            fx.transform.localScale = new Vector3(scaleBoom, scaleBoom);
            Destroy(fx, Duration);

        }
       Time.timeScale=1f;
    }

    public override void UpdateCoolDownTimer(float deltaTime)
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= deltaTime;
        }
    }
    public override void SetStatsForUpGrade(){

        if(level>=abilityStats.Count){
             level=abilityStats.Count-1;
        }
        scaleBoom=abilityStats[level].value;
    }
}

