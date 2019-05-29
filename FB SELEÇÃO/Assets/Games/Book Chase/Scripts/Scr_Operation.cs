using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Operation
{
    // Variables Random
    public float first;
    public float second;
    public float correct;
    public int operation; // 0 = dynamic | 1 = soma | 2 = subitração
    // variables Files
    public List<string> options;
    public string question;

    // Constructor
    public Scr_Operation(List<string> options, string question)
    {
        this.options = options;
        this.question = "Questão " + Scr_OptionGen.numQuestions.ToString() + ": " + question;
    }
    public Scr_Operation(float first, float second, int operation)
    {
        // Set values
        this.first = first;
        this.second = second;

        // Using Dynamic Operations
        if (operation == 0)
        {
            this.operation = Scr_OperationGen.ops.DynamicOperations();
        }

        // Creating the answer
        switch (this.operation)
        {
            case 1:
                correct = first + second;
                break;
            case 2:
                correct = first - second;
                break;
            case 3:
                correct = first * second;
                break;
            case 4:
                //first = result
                correct = first;
                if ((int)second == 0)
                {
                    second = Random.Range(2, 10);
                }
                this.first = second * correct;
                break;
        }

        // If wanted, make the answer never go below 0
        if (Scr_Config.conf.difficulty == false && correct < 0)
        {
            LogSave.ls.SaveLog("Min 0 Executado | ");
            correct = 0;
        }

    }
}
