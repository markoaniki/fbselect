using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_Option : MonoBehaviour
{
    [Header("Variables")]
    public string answer;
    public TextMesh text;
    public bool isCorrect = false;

    // Awake, Start & Update
    void Awake()
    {

    }
    void Start()
    {
        
    }
    void Update()
    {
        text.text = answer;
    }
}
