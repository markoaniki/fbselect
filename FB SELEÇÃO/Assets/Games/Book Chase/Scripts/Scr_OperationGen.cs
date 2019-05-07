using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_OperationGen : MonoBehaviour
{
    // Singleton
    public static Scr_OperationGen ops = null;

    // Variables
    public Scr_Operation answer = null;
    public GameObject textGo = null;
    private Text text = null;
    public int numOfOps = 4;
    public float chanceDecay = 2f;
    private List<float> percs = new List<float>();
    public string question;

    // Start & Update
    void Start()
    {
        if (ops == null)
        {
            ops = this;
            text = textGo.GetComponent<Text>();
            for (int i = 0; i < numOfOps; i++)
            {
                percs.Add(100 / numOfOps);
            }
        }
    }
    void Update()
    {
        if (answer != null)
        {
            if (Scr_Config.conf.isProcedural)
            {
                text.text = answer.question;
            }
            else
            {
                switch (answer.operation)
                {
                    case 1:
                        text.text = answer.first.ToString(Scr_Config.conf.TextFormat()) + " + " + answer.second.ToString(Scr_Config.conf.TextFormat()) + " = ???";
                        break;
                    case 2:
                        text.text = answer.first.ToString(Scr_Config.conf.TextFormat()) + " - " + answer.second.ToString(Scr_Config.conf.TextFormat()) + " = ???";
                        break;
                    case 3:
                        text.text = answer.first.ToString(Scr_Config.conf.TextFormat()) + " x " + answer.second.ToString(Scr_Config.conf.TextFormat()) + " = ???";
                        break;
                    case 4:
                        text.text = answer.first.ToString(Scr_Config.conf.TextFormat()) + " ÷ " + answer.second.ToString(Scr_Config.conf.TextFormat()) + " = ???";
                        break;
                }
            }
        }
    }

    public float ChanceAcumulator()
    {
        float acc = 0;
        foreach (float x in percs)
        {
            acc += x;
        }
        return acc;
    }

    // Dynamic Operations
    public int DynamicOperations()
    {
        float random = Random.Range(0, ChanceAcumulator());

        LogSave.ls.SaveLog("Dynamic Operations Executado | ");
        for (int i = 0; i < numOfOps; i++)
        {
            random -= percs[i];
            if (random < 0)
            {
                percs[i] -= chanceDecay;
                if (percs[i] < 5)
                {
                    percs[i] = 5;
                }
                return i + 1;
            }
        }
        return 1;
    }

    // Operation Creation
    public void CreateOperation()
    {
        if (Scr_Config.conf.isProcedural == false) {
            LogSave.ls.SaveLog("Create Operation Executado | ");
            answer = new Scr_Operation(Scr_Config.conf.RandomNum(1f, 10f), Scr_Config.conf.RandomNum(1f, 15f), 0);
            Scr_Config.conf.isFree = false;
        }
        else
        {
            // Corrigir
            SaveAndLoadQuestions.sad.setRdmQuestion();
            answer = new Scr_Operation(SaveAndLoadQuestions.sad.actQuestion.options, SaveAndLoadQuestions.sad.actQuestion.question);
            Scr_Config.conf.isFree = false;
        }
    }
}