using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : Singleton<PlayerHealth>
{
    // Start is called before the first frame update
    [Header("Health info")]

 public float maxHealth;
    public float health;
    [Header("Components info")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;

    void Start()
    {
        // slider=GetComponent<Slider>();
        health = maxHealth;
        healthSlider.value = 1;
        UpdateHPGUI();

    }

    // Update is called once per frame
    void Update()
    {
        // UpdateHPGUI();
            if(health>maxHealth){
                health=maxHealth;
            }

    }
    public void TakeDamage(float _damage)
    {

        float realDamage = Mathf.Min(_damage, health);
        health -= realDamage;
        
        UpdateHPGUI();

        if (health <= 0)
        {
            PassAway();
        }
    }
    void PassAway()
    {
        // Time.timeScale = 0;
        // SceneManager.LoadScene(0);
        GameManager.Instance.ChangeState(GameState.GAMEOVER);

    }
    public void UpdateHPGUI()
    {
        healthSlider.value = health / maxHealth;
        healthText.text = health + " / " + maxHealth;
    }
}
