using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Objects/Ability/Dash", order = 1)]
public class Dash : Ability
{
    // Start is called before the first frame update
    [SerializeField] private GameObject vfx;
    [SerializeField] private float coolDown;
    public float coolDownTimer;


    private void OnEnable()
    {
        coolDownTimer = 0f;
    }
    public override void Use()
    {

        if (coolDownTimer <= 0)
        {
            coolDownTimer = coolDown;
            GameObject fx = Instantiate(vfx, Player.Instant.transform.position,Quaternion.identity);
            // Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // worldPoint.z = 0;
            // Vector2 dir=worldPoint-Player.Instant.transform.position;
              fx.GetComponent<Rigidbody2D>().velocity = Player.Instant.currentDir.normalized * 10f;

        }
    }

    public override void UpdateCoolDownTimer(float deltaTime)
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= deltaTime;
        }
    }
}
