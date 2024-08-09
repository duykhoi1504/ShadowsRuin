using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Health info")]

    [SerializeField] private float maxHealth;
    private float health;
    [Header("Components info")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;

    void Start()
    {
        // slider=GetComponent<Slider>();
        health = maxHealth;
        healthSlider.value = 1;
        UpdateGUI();

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void TakeDamage(float _damage)
    {
        float realDamage = Mathf.Min(_damage, health);
        health -= realDamage;
        healthSlider.value = health / maxHealth;
        UpdateGUI();

        if (health <= 0)
        {
            // Time.timeScale = 0;
            SceneManager.LoadScene(0);

        }
    }
    private void UpdateGUI()
    {
        healthText.text = health + " / " + maxHealth;
    }
}
