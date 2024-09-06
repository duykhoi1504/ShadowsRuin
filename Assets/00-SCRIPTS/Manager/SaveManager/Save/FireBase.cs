using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FireBase : MonoBehaviour
{
    // Start is called before the first frame update
     private string databaseUrl = "https://shadowruin-be8ac-default-rtdb.asia-southeast1.firebasedatabase.app/";
     private List<PlayerData> scoresList = new List<PlayerData>();
    void Start()
    {
        StartCoroutine(GetRequest(databaseUrl+".json"));
        StartCoroutine(Upload());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:

                    break;
                case UnityWebRequest.Result.ProtocolError:

                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(webRequest.downloadHandler.text);
                    // string jsonResponse = webRequest.downloadHandler.text;
        
                    break;
            }
        }
    }
    public struct PlayerData{
        public int score;
    }
    IEnumerator Upload()
    {
        string url = databaseUrl + "score.json";
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
