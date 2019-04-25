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
    public float sumPerc = 0.5f;
    private Text text = null;
    public string question;
    
    // Start & Update
    void Start()
    {
        if(ops == null)
        {
            ops = this;
            text = textGo.GetComponent<Text>();
        }
    }
    void Update()
    {
        if(answer != null)
        {
            switch (answer.operation)
            {
                case 1:
                    text.text = answer.first.ToString(Scr_Config.conf.TextFormat()) + " + " + answer.second.ToString(Scr_Config.conf.TextFormat()) + " = ???";
                    break;
                case 2:
                    text.text = answer.first.ToString(Scr_Config.conf.TextFormat()) + " - " + answer.second.ToString(Scr_Config.conf.TextFormat()) + " = ???";
                    break;
            }
        }
    }

    // Dynamic Operations
    public int DynamicOperations()
    {
        float percentage = 100 * sumPerc;
        float random = Random.Range(0, 100);

        LogSave.ls.SaveLog("Dynamic Operations Executado | ");
        if (random <= percentage)
        {
            sumPerc -= 0.2f;
            return 1;
        }
        
         sumPerc += 0.2f;
         return 2;
    }

    // Operation Creation
    public void CreateOperation()
    {
        LogSave.ls.SaveLog("Create Operation Executado | ");
        answer = new Scr_Operation(Scr_Config.conf.RandomNum(1f, 20f), Scr_Config.conf.RandomNum(1f, 20f), 0);
        Scr_Config.conf.isFree = false;
    }
}
