using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_QuestGen : MonoBehaviour
{
    // Singleton
    public static S_QuestGen qg = null;
    public static bool phase = false; //false = phase 1 | true = phase 2;

    // Variables
    public List<Question> questions = new List<Question>();
    
    // Start and Update
    void Start()
    {
        if(qg == null)
        {
            qg = this;
        }
    }
    void Update()
    {
        
    }

    // Generate Question
    public void GenerateQuestion()
    {
        SaveAndLoadQuestions_FA.sad.setRdmQuestion();
        questions.Add(SaveAndLoadQuestions_FA.sad.actQuestion);
        SaveAndLoadQuestions_FA.sad.printScreenQuestion();
    }
}
