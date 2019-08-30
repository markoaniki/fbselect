using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LogServerTest : MonoBehaviour
{
   private string caminho = "http://localhost:3300/admin";
    
    //http://localhost/json/servidor.js
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(caminho);
        StartCoroutine(GetText());
    }

    IEnumerator GetText(){
        UnityWebRequest www = UnityWebRequest.Get(caminho);
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError){
            Debug.Log(www.error);
        }
        else{
            Debug.Log(www.downloadHandler.text);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
