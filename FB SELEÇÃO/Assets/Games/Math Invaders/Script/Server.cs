using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
 
public class Server : MonoBehaviour
{
    private string highscore_url = "http://localhost:3300/admin";
    string player;
    int score;

   void Start() {
        StartCoroutine(Upload());
        StartCoroutine(GetInfo(highscore_url));
    }

    IEnumerator GetInfo (string url) {
        UnityWebRequest www = UnityWebRequest.Get(url + "info");
        yield return www.SendWebRequest();
        string response = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
        
        Debug.Log(response);
        if (www.isNetworkError) 
            Debug.Log("error");
    }

    IEnumerator Upload() {
 
        WWWForm form = new WWWForm();
 
        form.AddField( "UserName", player );
 
        form.AddField( "Password", score );
 
        UnityWebRequest www = UnityWebRequest.Post(highscore_url, form);
        yield return www.SendWebRequest();
 
        if (www.isNetworkError || www.isHttpError)
        {
            print(www.error);
        }
    }
}

