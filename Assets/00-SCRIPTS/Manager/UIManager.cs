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
        // if (PlayerHealth.Instant.hasPlayerDead())
        // {
        //     LeanTween.delayedCall(3f, () => gameManager.ChangeState(GameState.GAMEOVER));
        // }

    }
    public void StartGameButton() => gameManager.ChangeState(GameState.GAMEPLAY);
    public void SkipShopButton() => gameManager.ChangeState(GameState.GAMEPLAY);
    public void GameOverButton() => SceneManager.LoadScene(0);



    public void UpdateCoinGUI(int _currentCoin)
    {
        coinText.text = _currentCoin.ToString();
    }
    public void UpdateXPGUI(int currentXP, int requireXP, int level)
    {
        sliderXP.value = (float)currentXP / requireXP;
        text.text = "level " + (level + 1);
    }


// public void SetButtonUpgrade(){
//        for (int i = 0; i < levelUpButon.Length; i++)
//         { 
//             levelUpButon[i].SelectUpgrade();
//             if( levelUpButon[i].isClicked)
//             {
//                 ShopContainer.SetActive(false);
//             }
//             levelUpButon[i].button.onClick.RemoveAllListeners();
//             levelUpButon[i].button.onClick.AddListener(() =>GameManager.Instance.ChangeState(GameState.GAMEPLAY));

//         }
// }
}
