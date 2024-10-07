using System.Collections;
// using System.Collections.Generic;
// using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.Networking;

public class FireBase : MonoBehaviour
{
    // Start is called before the first frame update
    private string URL = "https://shadowruin-be8ac-default-rtdb.asia-southeast1.firebasedatabase.app/";
    [SerializeField] PLayerData scoresList;
    [SerializeField] private GameContentSO gameContentSO;
    void Start()
    {
        // StartCoroutine(GetRequest(uri + ".json"));
        // StartCoroutine(Upload());
        StartCoroutine(GetRequest());


        // gameContentSO
    }

    // Update is called once per frame
    void Update()
    {
        // StartCoroutine(GetRequest());
        // JsonObject
    }
    IEnumerator GetRequest()
    {
        string url = URL + ".json";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = url.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:

                    break;
                case UnityWebRequest.Result.ProtocolError:

                    break;
                case UnityWebRequest.Result.Success:
                    // Debug.Log(webRequest.downloadHandler.text);
                    string json = webRequest.downloadHandler.text;
                    SimpleJSON.JSONNode score = SimpleJSON.JSON.Parse(json);
                    // scoresList.HP = score["HP"];
                    // scoresList.speed = score["speed"];
                    // foreach (var a in score["score"])
                    // {
                    //     int value = a.Value["score"].AsInt; // The score value
                    //     scoresList.score.Add(value); // Add the score to the list
                    // }

                    break;
            }
        }
    }
    // [System.Serializable]
    // public struct PlayerData
    // {
    //     public int HP;

    //     public List<int> score;
    //     public int speed;

    // }
    IEnumerator Upload()
    {
        string url = URL + "score.json";
        using (UnityWebRequest www = UnityWebRequest.Post(url, "{ \"score\": 1}", "application/json"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
