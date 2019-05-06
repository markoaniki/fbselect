using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Option : MonoBehaviour
{
    // Variables
    public float answer;
    public AudioClip audClip;
    public AudioSource audSauce;

    // Start & Update
    void Start()
    {
        audSauce.clip = audClip;
        answer = Scr_Config.conf.IsInteger(answer);
        TextMesh tm = this.GetComponentInChildren<TextMesh>();
        tm.text = answer.ToString(Scr_Config.conf.TextFormat());
        audSauce.Play();
    }
    void Update()
    {
        
    }
}
