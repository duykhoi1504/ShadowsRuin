using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    GameManager gameManager;
  public LevelUpSelectionButton[] levelUpButon;
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


// public void SetButtonUpgrade(){
//        for (int i = 0; i < levelUpButon.Length; i++)
//         { 
//             levelUpButon[i].SelectUpgrade();
//             levelUpButon[i].button.onClick.RemoveAllListeners();
//             levelUpButon[i].button.onClick.AddListener(() =>GameManager.Instance.ChangeState(GameState.GAMEPLAY));

//         }
// }
    public void StartGameButton() => gameManager.ChangeState(GameState.GAMEPLAY);
    public void SkipShopButton() => gameManager.ChangeState(GameState.GAMEPLAY);
    public void GameOverButton() => SceneManager.LoadScene(0);  

}
