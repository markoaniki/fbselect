using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoEntrar : MonoBehaviour
{
    public string toCall;
    // public AudioClip audClip;
    // public AudioSource audSauce;

    // Start is called before the first frame update
    void Start()
    {
        // audSauce.clip = audClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene(toCall);
        }
    }
}
