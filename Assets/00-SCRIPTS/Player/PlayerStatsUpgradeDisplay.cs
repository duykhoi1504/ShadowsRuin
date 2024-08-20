using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUpgradeDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    Button button;
    [SerializeField] TextMeshProUGUI coinText, valueText, labelText;
    [SerializeField] GameObject purchaseText;


    //gia tri dc luu trong moi card
    int coinCard;
    float valueCard;
    PlayerStats stats;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    private void Start()
    {

        button.onClick.AddListener(SelectPlayerStatsCard);
    }
    // private void Update()
    // {
    //     button.onClick.AddListener(() => SelectPlayerStatsCard());
    // }

    public void UpgradePlayerStatsButtonDisplay(int coin, float value, string name, PlayerStats _stats)
    {
        stats = _stats;
        labelText.text = name;

        coinText.text = coin.ToString();
        valueText.text = "value: +" + value.ToString();

        coinCard = coin;
        valueCard = value;
        bool isEnoughCoin = !(PlayerCoin.Instant.CurrentCoin < coin);
        button.enabled = isEnoughCoin;
        purchaseText.gameObject.SetActive(isEnoughCoin);
    }
    public void SelectPlayerStatsCard()
    {
        PlayerCoin.Instant.CurrentCoin -= coinCard;
        //
        switch (stats)
        {
            case PlayerStats.moveSpeed:
                Player.Instant.moveSpeed += valueCard;

                break;
            case PlayerStats.maxHealth:
                PlayerHealth.Instant.maxHealth += valueCard;
                PlayerHealth.Instant.UpdateHPGUI();


                break;
            case PlayerStats.pickUpRange:
                PlayerDetection.Instant.rangeCollect += valueCard;


                break;
            case PlayerStats.health:
                PlayerHealth.Instant.health += (int)valueCard;
                PlayerHealth.Instant.UpdateHPGUI();


                break;
        }
        GameManager.Instance.ChangeState(GameState.GAMEPLAY);

    }
}
