using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(UIManager))]
public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance => _instance;
    public GameState currentState;



    // public UpgradeManager upgradeManager;

    [Header("BUTON")]

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject shopPanel;

    [SerializeField] private GameObject gameoverPanel;
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
    }





    public void WaveComplete()
    {
        if (Player.Instance.HasLevelUp())
        {
            ChangeState(GameState.SHOP);
        }
    }
    public void ChangeState(GameState gameState)
    {
        currentState = gameState;
        // handleStateChange();
        StartCoroutine(gameState.ToString() + "State");
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
        // upgradeManager.setButtonUpgrade();
        while (currentState == GameState.SHOP)
        {
            yield return null;
        }
        shopPanel.SetActive(false);
    }
    IEnumerator GAMEOVERState()
    {
        Time.timeScale = 0f;
        gameoverPanel.SetActive(true);
        // LeanTween.delayedCall(2,()=>SceneManager.LoadScene(0));
        while (currentState == GameState.GAMEOVER)
        {
            yield return null;
        }
        gameoverPanel.SetActive(false);

    }
}
