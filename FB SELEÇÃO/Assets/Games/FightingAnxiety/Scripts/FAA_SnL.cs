using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class FAA_SnL : MonoBehaviour
{
    // Serializable 
    public static FAA_SnL sad = null;

    [SerializeField]
    private List<Question> Questions = new List<Question>();

    [Header("General Settings")]
    public bool automatic = false;
    public Text text;
    public List<GameObject> buttons = new List<GameObject>();

    [Header("Equation Non-Randomized Settings")]
    public string PathR;
    public char splitchar = '|';

    [Header("Equation Randomizer Settings")]
    public string PathM;
    public float maxValue = 50f;

    public Question actQuestion = null;
    public Question act2Question = null;
    // Start is called before the first frame update
    private void Awake()
    {
        if (sad == null) sad = this;
    }
    private void Start()
    {
        loader();
        //setRdmQuestion();
        //printOptions();
    }

    StreamReader loadText()
    {
        if (automatic) { return new StreamReader(PathM, Encoding.UTF8); }
        return new StreamReader(PathR, Encoding.UTF8);
    }

    void loadNonRandom(StreamReader sReader)
    {
        string line;
        while (true)
        {
            line = sReader.ReadLine();
            if (line == null) { break; }
            string[] entries = line.Split(splitchar);
            int length = entries.Length;
            if (length >= 2)
            {
                Question q = new Question();

                q.question = entries[0];

                for (int i = 1; i < length; i++) { q.options.Add(entries[i]); }

                Questions.Add(q);
            }
        }
    }

    List<string> splitEquation(string splited)
    {
        List<string> equ = new List<string>();

        string str = "";

        int i = 0;

        int counter = 0;

        if (splited[i] == '(')
        {
            i++;
            do
            {
                char c = splited[i];
                if (c == '(') { counter++; }
                if (c == ')') { counter--; }
                str += c;
                i++;
            } while (splited[i] == ')' && counter == 0);
        }
        else
        {
            str = splited[i].ToString();
        }

        equ.Add(str);
        i++;
        equ.Add(splited[i].ToString());

        i++;

        str = "";
        if (splited[i] == '(')
        {
            i++;
            do
            {
                char c = splited[i];
                if (c == '(') { counter++; }
                if (c == ')') { counter--; }
                str += c;
                i++;
            } while (splited[i] == ')' && counter == 0);
        }
        else
        {
            str = splited[i].ToString();
        }

        equ.Add(str);

        return equ;
    }

    int constructEquations()
    {
        //splitEquation();
        return 0;
    }

    void loadRandom(StreamReader sReader)
    {
        string line;

        line = sReader.ReadLine();
        if(line == null) { Debug.Log("Error"); return; }
        List<string> baseEqu = splitEquation(line);
        Debug.Log(baseEqu.Count);
    }

    void loader()
    {
        try
        {
            StreamReader sReader = loadText();

            using (sReader)
            {
                if (automatic)
                {
                    //TODO
                    loadRandom(sReader);
                }
                else
                {
                    loadNonRandom(sReader);
                }
                sReader.Close();
            }

        }
        catch (Exception e) { Debug.Log(e); }
    }

    //Original
    public void setRdmQuestion()
    {
        int count = Questions.Count;
        if (count == 0) { return; }
        int index = UnityEngine.Random.Range(0, count);
        Debug.Log("Even");
        actQuestion = Questions[index];
        Questions.RemoveAt(index);
        text.text = actQuestion.question;
    }
    //Sobrecarga
    public void setRdmQuestion(int noo)
    {
        int count = Questions.Count;
        if (count == 0) { return; }
        int index = UnityEngine.Random.Range(0, count);
        while (index % 2 != 0)
        {
            Debug.Log("ODD");
            index = UnityEngine.Random.Range(0, count);
        }
        Debug.Log("Even");
        actQuestion = Questions[index];
        act2Question = Questions[index + 1];
        Questions.RemoveAt(index + 1);
        Questions.RemoveAt(index); 
    }

    public void printScreenQuestion()
    {
        if (S_QuestGen.phase != true) {
            S_Config.conf.noquest += 1;
            text.text = "DESAFIO " + S_Config.conf.noquest.ToString() + "\n" + actQuestion.question;
        }
        else if (S_QuestGen.phase)
        {
            S_Config.conf.noquest += 1;
            text.text = "DESAFIO " + S_Config.conf.noquest.ToString() + "\n" + act2Question.question;
        }
    }

    void printOptions()
    {
        if (Questions.Count == 0) { return; }
        string str = "";
        foreach(string f in actQuestion.options)
        {
            str += f.ToString() + splitchar;
        }
        Debug.Log(str);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
