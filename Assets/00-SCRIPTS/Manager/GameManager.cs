using System.Collections;
// using System.Collections.Generic;
// using UnityEditor.SearchService;
using UnityEngine;
// using UnityEngine.SceneManagement;
// using System;
using TMPro;
// using System.Threading;


public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameContentSO gameContentSO;
    public GameContentSO GameContentSO { get => gameContentSO; set => gameContentSO = value; }

    public GameState currentState;
    // public Action onPlayerLevelUp;

    // [Header("Timer info")]

    // public float gameTimer;
    public TextMeshProUGUI gameTimerText;
    [Header("Gameover info")]
    public TextMeshProUGUI timeSurvire;
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI Level;



    [Header("BUTON")]

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject scorePanel;

    [SerializeField] private GameObject pausePanel;


    [SerializeField] private GameObject inventoryPanel;


    [SerializeField] private GameObject gameoverPanel;

    // public static Action OnNewGame;

    //  Action onWaveComplete;


    private void Start()
    {


        Time.timeScale = 0.0f;
        Application.targetFrameRate = 60;
        ChangeState(GameState.GAMEPLAY);



    }
    private void Update()
    {
        // WaveComplete();
        // if (currentState == GameState.GAMEPLAY)
        // {
        //     gameTimer += Time.deltaTime;
        //     updateTimer(gameTimer);
        // }

    }



    // private void endLevel()
    // {
    //     float minutes = Mathf.FloorToInt(gameTimer / 60f);
    //     //chia lay du time= 60 % 60 du 0
    //     float seconds = Mathf.FloorToInt(gameTimer % 60f);
    //     timeSurvire.text = minutes.ToString() + " mins " + seconds.ToString() + " secs";
    // }
    // private string TimeToString()
    // {
    //     float minutes = Mathf.FloorToInt(gameTimer / 60f);
    //     //chia lay du time= 60 % 60 du 0
    //     float seconds = Mathf.FloorToInt(gameTimer % 60f);

    //     return minutes.ToString() + " mins " + seconds.ToString() + " secs";
    // }
    // public void WaveComplete()
    // {
    //     if (Player.Instant.HasLevelUp())
    //     {
    //         ChangeState(GameState.SHOP);
    //         UIManager.Instant.ShopContainer.SetActive(true);
    //         onPlayerLevelUp?.Invoke();


    //         // PlayerStatsManager.Instant.SetStatsRandButton();
    //         // PlayerWeaponManager.Instant.SetRandomCard();
    //     }
    // }
    public void ChangeState(GameState gameState)
    {
        currentState = gameState;
        // handleStateChange();
        StartCoroutine(gameState.ToString() + "State");
    }
    IEnumerator MENUState()
    {
        Time.timeScale = 0f;

        menuPanel.SetActive(true);
        while (currentState == GameState.MENU)
        {
            yield return null;
        }
        menuPanel.SetActive(false);
    }
    IEnumerator NEWGAMEState()
    {
        Time.timeScale = 1f;
        gamePanel.SetActive(true);
        //reset random skill moi lan restart new gameplay
        AbilityManager.Instant.ListAbilitysUse();
        if (PlayerScore.Instant)
        {
            PlayerScore.Instant.ResetScore();
        }
        // ChangeState(GameState.GAMEPLAY);
        while (currentState == GameState.NEWGAME)
        {
            yield return null;
        }
        // gamePanel.SetActive(false);
    }
    IEnumerator GAMEPLAYState()
    {
        Time.timeScale = 1f;
        gamePanel.SetActive(true);
        while (currentState == GameState.GAMEPLAY)
        {
            yield return null;
        }
        gamePanel.SetActive(false);
    }

    IEnumerator SHOPState()
    {
        Time.timeScale = 0f;
        shopPanel.SetActive(true);

        // UpgradeManager.Instance.setButtonUpgrade();

        while (currentState == GameState.SHOP)
        {
            yield return null;
        }
        shopPanel.SetActive(false);
    }

    IEnumerator INVENTORYState()
    {
        Time.timeScale = 0f;
        // UpgradeManager.Instance.setButtonUpgrade();
        // InventoryManager.Instant.ListItems();
        // InventoryManager.Instant.ListAbilityValid();
        inventoryPanel.SetActive(true);

        while (currentState == GameState.INVENTORY)
        {
            yield return null;
        }
        inventoryPanel.SetActive(false);
    }
    IEnumerator GAMEOVERState()
    {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;

        AudioManager.Instant.PlayerMusic(CONTANST.gameover);
        PlayerScore.Instant.AddHighScore(WaveManager.Instant.TimeToString());
        WaveManager.Instant.endLevel();
        totalScore.text = $"Score: {PlayerScore.Instant.Score.ToString()}";
        Level.text = $"Level: {PlayerLevel.Instant.Level.ToString()}";


        // OnNewGame?.Invoke();
        gameoverPanel.SetActive(true);
        // LeanTween.delayedCall(2,()=>SceneManager.LoadScene(0));
        while (currentState == GameState.GAMEOVER)
        {
            yield return null;
        }
        gameoverPanel.SetActive(false);

    }
    IEnumerator SCOREMENUState()
    {
        Time.timeScale = 0f;
        scorePanel.SetActive(true);
        // ScoreMenuManager.Instant.ListScore();
        while (currentState == GameState.SCOREMENU)
        {
            yield return null;
        }
        scorePanel.SetActive(false);

    }
    IEnumerator OPTIONState()
    {
        Time.timeScale = 0f;
        optionPanel.SetActive(true);
        while (currentState == GameState.OPTION)
        {
            yield return null;
        }
        optionPanel.SetActive(false);

    }
    IEnumerator PAUSEState()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        while (currentState == GameState.PAUSE)
        {
            yield return null;
        }
        pausePanel.SetActive(false);

    }

    // private void handleStateChange()
    // {
    //     switch (currentState)
    //     {
    //         case GameState.MENU:
    //             Debug.Log("menu state");
    //             Time.timeScale = 0.0f;

    //             break;
    //         case GameState.GAMEPLAY:

    //             Time.timeScale = 1f;
    //             Debug.Log("gameplay state");
    //             break;
    //         case GameState.SHOP:
    //             Time.timeScale = 0.0f;
    //             Debug.Log("SHOP state");
    //             break;
    //     }
}
