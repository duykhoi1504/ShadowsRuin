using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text level;
    [SerializeField] Text health;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        level.text = $"level: {PlayerLevel.Instant.Level+1}";


        health.text = $"Health: {PlayerHealth.Instant.maxHealth}";

    }
}
