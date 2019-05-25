using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Config : MonoBehaviour
{
    // Variables
        // Number of the question
    public int noquest = 0;
    public int maxquest = 10;
        // is Integer
    public bool isInteger = true;
        // Game Time
    private float gtime = 0;
        // Scores
    public float scores = 0;

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
            return Mathf.Floor(Random.Range(min, max));
        } else return (Random.Range(min, max));
    }

}
