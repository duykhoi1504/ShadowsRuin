using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Objects/Ability/Thunder", order = 1)]
public class Thunder : Ability
{
    // Start is called before the first frame update
    [SerializeField] private GameObject vfx;

    // public float coolDownTimer;
    [SerializeField] private float distance;

    public float Distance { get => distance; set => distance = value; }

    protected override void OnEnable()
    {
         base.OnEnable();
        isPlaySFx = true;

        coolDownTimer = 0f;
             SetStatsForUpGrade();
    }
    public override void Use()
    {
            if (isPlaySFx)
        {
            isPlaySFx = false;
            AudioManager.Instant.PlaySFX(CONTANST.thunder);
        }
        Vector3[] directions = {
            Player.Instant.transform.position+Vector3.up*distance,
            Player.Instant.transform.position+Vector3.down*distance,
            Player.Instant.transform.position+Vector3.left*distance,
            Player.Instant.transform.position+Vector3.right*distance
            };
        if (coolDownTimer <= 0)
        {
            coolDownTimer = CoolDown;
            foreach (Vector3 dir in directions)
            {
                GameObject fx = Instantiate(vfx, dir, Quaternion.identity);
                // GameObject fx = Instantiate(vfx, Player.Instant.transform.position, Quaternion.identity);
                // Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // worldPoint.z = 0;
                // Vector2 dir = worldPoint - Player.Instant.transform.position;

                Destroy(fx, Duration);

            }
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
          if(level>=abilityStats.Count){
             level=abilityStats.Count-1;
        }
        distance=abilityStats[level].value;
    }
}
