using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Option : MonoBehaviour
{
    // Variables
    public float answer;

    // Start & Update
    void Start()
    {
        answer = Scr_Config.conf.IsInteger(answer);
        TextMesh tm = this.GetComponentInChildren<TextMesh>();
        tm.text = answer.ToString(Scr_Config.conf.TextFormat());
    }
    void Update()
    {
        
    }
}
