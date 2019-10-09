using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Reload : MonoBehaviour
{
    public string tocall;

    // Awake, Start e Update
    void Start()
    {
        //tocall = SceneManager.GetActiveScene().name;
    }
    void Update()
    {
        
    }

    public void onClick()
    {
        SceneManager.LoadScene(tocall, LoadSceneMode.Single);
    }
}
