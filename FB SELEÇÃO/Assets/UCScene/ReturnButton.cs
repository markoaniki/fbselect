using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    public string retPath = "";
    public string MapPath = "";

    public void Return()
    {
        Debug.Log("OK");

        SceneManager.LoadScene(retPath, LoadSceneMode.Single);
    }
}
