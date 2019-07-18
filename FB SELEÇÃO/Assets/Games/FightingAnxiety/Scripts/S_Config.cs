using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    public int idCode = 1510518;

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

    // SaveFile
    public void FAA_SaveFile()
    {
        FAA_SavedInfo si = new FAA_SavedInfo(gtime, scores, maxquest, noquest, idCode);
        string json = JsonUtility.ToJson(si);
        Directory.CreateDirectory(Application.dataPath + "\\Saves\\" + idCode.ToString() + "\\FightingAgainstAnsiety");
        File.WriteAllText(Application.dataPath + "\\Saves\\" + idCode.ToString() + "\\FightingAgainstAnsiety\\" + "FAA_SaveFile.json", json);
    }

}

[Serializable]
public class FAA_SavedInfo
{
    public float time;
    public float scores;
    public int maxQuestion;
    public int numberOfQuestions;
    public int ID;

    public FAA_SavedInfo(float time, float scores, int maxQuestion, int numberOfQuestions, int ID)
    {
        this.time = time;
        this.scores = scores;
        this.maxQuestion = maxQuestion;
        this.numberOfQuestions = numberOfQuestions;
        this.ID = ID;
    }
}
