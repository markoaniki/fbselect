using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
 
public class Server : MonoBehaviour
{
    string highscore_url = "http://localhost:5500/";
    string player;
    int score;
 
   void Start() {
        StartCoroutine(Upload());
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