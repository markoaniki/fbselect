using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questao
{
    public int QuestionID { get; }
    public float HitPercentage { get; set; }
    public bool IsDone { get; set; }

    public Questao(int id)
    {
        QuestionID = id;
        IsDone = false;
    }

    public void beginQuestion()
    {
        IsDone = false;
    }

    public void endQuestion(float hitPercentage)
    {
        HitPercentage = hitPercentage;
        IsDone = true;
    }
}