using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject loadPage;
    [SerializeField] Slider slider;
    public void loadScene()
    {
        loadPage.SetActive(true);
        StartCoroutine(LoadSceneAsync(1));
    }
    IEnumerator LoadSceneAsync(int index)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(index);
        while (!loadOperation.isDone)
        {
            float progesValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            slider.value = progesValue;
            yield return null;
        }
    }
}
