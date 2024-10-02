using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class UIManager : Singleton<UIManager>
{


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




    void Start()
    {
        
    }

    private void Update()
    {
        if (diamondText != null)
            UpdateDiamondGUI(GameManager.Instant.GameContentSO.Diamond);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButton();
        }
    }


    public void StartGameButton() => GameManager.Instant.ChangeState(GameState.NEWGAME);

    public void SkipShopButton() => GameManager.Instant.ChangeState(GameState.GAMEPLAY);
    public void BackToStartMenu() => SceneManager.LoadScene(0);

    public void ReTryButton() => SceneManager.LoadScene(2);
    public void BackToLobby() => SceneManager.LoadScene(1);
    public void ScoreMenuButton ()=> GameManager.Instant.ChangeState(GameState.SCOREMENU);
    public void OptionButton() => GameManager.Instant.ChangeState(GameState.OPTION);
    public void MenuButton() => GameManager.Instant.ChangeState(GameState.MENU);
    public void PauseButton() => GameManager.Instant.ChangeState(GameState.PAUSE);
    public void InventoryButton() => GameManager.Instant.ChangeState(GameState.INVENTORY);


    public void ExitButon() => Application.Quit();
      public void CloseInventory() =>GameManager.Instant.ChangeState(GameState.GAMEPLAY);
    public void Save(){
       SaveSystem.Instant.SaveData();
    }
      public void Load(){
       SaveSystem.Instant.LoadData();
        
    }

    
    public void UpdateCoinGUI(int _currentCoin)
    {
        coinText.text = _currentCoin.ToString();
    }
    public void UpdateScoreGUI(int _currentScore)
    {
        if(scoreText)
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
