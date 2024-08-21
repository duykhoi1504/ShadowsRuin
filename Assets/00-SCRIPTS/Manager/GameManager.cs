using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using System.Threading;


public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance => _instance;
    public GameState currentState;

    [Header("Timer info")]

    public float gameTimer;
    public TextMeshProUGUI gameTimerText;
     [Header("Gameover info")]
    public TextMeshProUGUI timeSurvire;

    [Header("BUTON")]

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject shopPanel;

    [SerializeField] private GameObject gameoverPanel;


    //  Action onWaveComplete;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // upgradeManager = GetComponent<UpgradeManager>();
        Time.timeScale = 0.0f;
        Application.targetFrameRate = 60;
        ChangeState(GameState.MENU);


    }
    private void Update()
    {
        WaveComplete();
        if (currentState == GameState.GAMEPLAY)
        {
            gameTimer += Time.deltaTime;
            updateTimer(gameTimer);
        }

        

    }


    private void updateTimer(float time)
    {


        float minutes = Mathf.FloorToInt(time / 60f);
        //chia lay du time= 60 % 60 du 0
        float seconds = Mathf.FloorToInt(time % 60f);

        gameTimerText.text = minutes.ToString() + ":" + seconds.ToString();
    }
    private void endLevel()
    {


        float minutes = Mathf.FloorToInt(gameTimer / 60f);
        //chia lay du time= 60 % 60 du 0
        float seconds = Mathf.FloorToInt(gameTimer % 60f);


        timeSurvire.text = minutes.ToString() + " mins " + seconds.ToString()+ " secs";
    }

    public void WaveComplete()
    {
        if (Player.Instant.HasLevelUp())
        {
            ChangeState(GameState.SHOP);
            PlayerStatsManager.Instant.SetStatsRandButton();
            PlayerManager.Instance.SetRandomCard();
        }
    }
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
    IEnumerator GAMEOVERState()
    {
        yield  return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        endLevel();
        gameoverPanel.SetActive(true);
        // LeanTween.delayedCall(2,()=>SceneManager.LoadScene(0));
        while (currentState == GameState.GAMEOVER)
        {
            yield return null;
        }
        gameoverPanel.SetActive(false);

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
