using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Config : MonoBehaviour
{
    // Variables
    [Header("Question Related Variables")]
    public int maxquest = 10;
    public int noquest = 0;
    public float scores = 0;
    [Header("Booleans")]
    public bool isInteger = true;
    public bool isAttacking = false;
    [Header("Game Settings")]
    private float gtime = 0;

    // Singleton
    public static S_Config conf = null;

    // Start & Update
    void Start()
    {
        if(conf == null)
        {
            conf = this;
        }
    }
    void Update()
    {
        gtime += Time.deltaTime;
    }

    // Methods
        // Get & Set
    public void SetTime(float gtime)
    {
        this.gtime = gtime;
    }
    public float GetTime()
    {
        return gtime;
    }
        // Random Number
    public float RandomNum(float min, float max)
    {
        if (isInteger)
        {
            return Mathf.Floor(UnityEngine.Random.Range(min, max));
        } else return (UnityEngine.Random.Range(min, max));
    }

}

[Serializable]
public class FAA_SavedInfo
{
    public float time;
    public float scores;
    public int maxQuestion;
    public int numberOfQuestions;
}
