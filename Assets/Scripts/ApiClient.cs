using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ApiClient : MonoBehaviour
{
    private const string BASE_URL = "https://dabkunk.com/api/";

    public void SaveScore(string username, int score)
    {
        StartCoroutine(SendScore(username, score));
    }

    IEnumerator SendScore(string username, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("score", score);

        using (UnityWebRequest req =
            UnityWebRequest.Post(BASE_URL + "save_score.php", form))
        {
            yield return req.SendWebRequest();

            if (req.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(req.error);
            }
            else
            {
                Debug.Log(req.downloadHandler.text);
            }
        }
    }
    public static ApiClient Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
