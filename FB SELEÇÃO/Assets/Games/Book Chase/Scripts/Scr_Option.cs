using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Option : MonoBehaviour
{
    // Variables
    public string answer;
    public bool correct = false;
    public AudioClip audClip;
    public AudioSource audSauce;

    // Start & Update
    void Start()
    {
        audSauce.clip = audClip;
        //answer = Scr_Config.conf.IsInteger(answer);
        TextMesh tm = this.GetComponentInChildren<TextMesh>();
        tm.text = answer;
        audSauce.Play();
    }
    void Update()
    {
        
    }
}
