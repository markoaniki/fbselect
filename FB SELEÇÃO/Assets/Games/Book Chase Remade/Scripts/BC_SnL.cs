using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BC_SnL : MonoBehaviour
{
    // Singleton
    public static BC_SnL snl = null;

    [SerializeField]
    public static List<Question> Questions = new List<Question>();

    [Header("General Settings (NEVER TURN AUTOMATIC ON)")]
    public bool automatic = false;

    public List<GameObject> buttons = new List<GameObject>();

    [Header("Equation Non-Randomized Settings")]
    public string path_R;
    public char splitcher = '|';

    [Header("Equation Radomized Settings")]
    public string path_M;
    public float maxValue = 50f;

    public Question actQuest = null;

    // Awake, Start & Update
    void Awake()
    {
        if (snl == null) snl = this;
    }
    void Start()
    {
        Loader();
    }
    void Update()
    {
        
    }

    // Load Methods
    public void Loader()
    {
        try
        {
            StreamReader sReader = LoadText();
            using (sReader)
            {
                if (automatic)
                {
                    // TODO
                    LoadRandom(sReader);
                }
                else
                {
                    LoadNonRandom(sReader);
                }
                sReader.Close();
            }
        }
        catch (Exception e) { Debug.Log(e); }
    }
    public StreamReader LoadText()
    {
        if (automatic) { return new StreamReader(path_M, Encoding.UTF8); }
        return new StreamReader(path_R, Encoding.UTF8);
    }
    public void LoadNonRandom(StreamReader sReader)
    {
        string line;
        while (true)
        {
            line = sReader.ReadLine();
            if(line == null) { break; }
            string[] entries = line.Split(splitcher);
            int lenght = entries.Length;
            if(lenght >= 2)
            {
                Question q = new Question();
                q.question = entries[0];
                for(int i = 1; i < lenght; i++) { q.options.Add(entries[i]); }
                Questions.Add(q);
            }
        }
    }
    public void LoadRandom(StreamReader sReader)
    {
        string line;

        line = sReader.ReadLine();
        if (line == null) { Debug.Log("Error"); return; }
        List<string> baseEqu = SplitEquation(line);
        Debug.Log(baseEqu.Count);
    }

    // Equation Methods
    public List<string> SplitEquation(string splited)
    {
        List<string> equ = new List<string>();

        string str = "";
        int i = 0;
        int counter = 0;

        if(splited[i] == '(')
        {
            i++;
            do
            {
                char c = splited[i];
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
    public int ConstructEquations()
    {
        //splitEquation();
        return 0;
    }

    // Set Methods
    public void SetRandomQuest()
    {
        int count = Questions.Count;
        if (count == 0) { return; }
        int index = UnityEngine.Random.Range(0, count);
        actQuest = Questions[index];
        Questions.RemoveAt(index);
    }

    // Other Methods
    public void PrintOptions()
    {
        if(Questions.Count == 0) { return; }
        string str = "";
        foreach (string f in actQuest.options)
        {
            str += f.ToString() + splitcher;
            Debug.Log(str);
        }
    }
}