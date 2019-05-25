using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Scr_QuestSave
{
    // Variables
    public int id;
    public float scores;
    public bool isCorrect = false;

    // Constructor
    public Scr_QuestSave(int id, float scores)
    {
        this.id = id;
        this.scores = scores;
    }

}
