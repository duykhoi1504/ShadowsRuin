using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    GameManager gameManager;
    public LevelUpSelectionButton[] levelUpButon;
    public GameObject ShopContainer;
    [Header("EXP BAR info")]
    [SerializeField] Slider sliderXP;
    [SerializeField] TextMeshProUGUI text;
    [Header("Coin BAR info")]
    [SerializeField] private TextMeshProUGUI coinText;
   [Header("diamon info")]
    public TextMeshProUGUI diamondText;
    [Header("Score BAR info")]

    [SerializeField] private TextMeshProUGUI scoreText;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameManager);
    }

    void Start()
    {
        gameManager = GameManager.Instance;

    }

    private void Update()
    {

    }
    public void StartGameButton() => gameManager.ChangeState(GameState.NEWGAME);
    
    public void SkipShopButton() => gameManager.ChangeState(GameState.GAMEPLAY);
    public void GameOverButton() => SceneManager.LoadScene(1);
    public void BackToLobby() => SceneManager.LoadScene(0);
    
    public void OptionButton() => gameManager.ChangeState(GameState.OPTION);
    public void MenuButton() => gameManager.ChangeState(GameState.MENU);
    
    

    public void ExitButon() {
        Application.Quit();
    }


    public void UpdateCoinGUI(int _currentCoin)
    {
        coinText.text = _currentCoin.ToString();
    }
      public void UpdateScoreGUI(int _currentScore)
    {
        scoreText.text = _currentScore.ToString();
    }
       public void UpdateDiamondGUI(int _currentDiamond)
    {
        diamondText.text = _currentDiamond.ToString();
    }
    public void UpdateXPGUI(int currentXP, int requireXP, int level)
    {
        sliderXP.value = (float)currentXP / requireXP;
        text.text = "level " + (level + 1);
    }



}
