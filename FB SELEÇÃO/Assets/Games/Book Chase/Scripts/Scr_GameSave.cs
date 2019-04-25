using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_GameSave : MonoBehaviour
{
    // Sigleton
    public static Scr_GameSave sav = null;

    // Variables
    public int maxQuestNum = 30;
    public List<Scr_QuestSave> questList = new List<Scr_QuestSave>(); // Lista de questões
    public float gameTime = 0f; // Tempo de jogo
    public float scores; // Scores totais
    public int register = 151; // Número de inscrição
    public string toCall;

    void Awake()
    {
        if (sav == null)
        {
            sav = this;
        }
    }

    // Start & Update
    void Start()
    {
        if(sav == null)
        {
            sav = this;
        }
    }
    void Update()
    {
        gameTime += Time.deltaTime;
    }

    // Save & Load
    public void SaveFile()
    {
        LogSave.ls.SaveLog("SaveFile executed | ");
        sav.scores = TotalScores();
        SaveFile save = new SaveFile(sav.questList, sav.gameTime, sav.scores, sav.register);
        string json = JsonUtility.ToJson(save);
        File.WriteAllText(Application.dataPath + "\\Saves\\" + sav.register.ToString() + "_BC_SaveFile.json", json);

        if (questList.Count >= maxQuestNum)
        {
            SceneManager.LoadScene(toCall, LoadSceneMode.Single);
        }
    }
    public void LoadFile()
    {
        if (File.Exists(Application.dataPath + "\\Saves\\" + sav.register.ToString() + "_BC_SaveFile.json"))
        {
            // Convert info
            string json = File.ReadAllText(Application.dataPath + "\\Saves\\" + sav.register.ToString() + "_BC_SaveFile.json");
            SaveFile save = JsonUtility.FromJson<SaveFile>(json);
            Debug.Log(save.sav_register.ToString());
            Debug.Log(sav.register.ToString());
            
            if (save.sav_qList.Count > 0 && save.sav_qList.Count < maxQuestNum)
            {
                //Change values
                sav.questList = save.sav_qList;
                sav.gameTime = save.sav_gTimes;
                sav.scores = save.sav_scorer;
                sav.register = save.sav_register;
            }
            /*else if (save.sav_qList.Count >= maxQuestNum)
            {
                SceneManager.LoadScene(toCall, LoadSceneMode.Single);
            }*/
        }
    }

    // Sum of total scores
    public float TotalScores()
    {
        LogSave.ls.SaveLog("Total Scores Started | ");
        int size = sav.questList.Count - 1;
        float scores = 0f;

        while (size >= 0)
        {
            if (sav.questList[size].isCorrect)
            {
                scores = scores + sav.questList[size].scores;
            }
            size--;
        }
        LogSave.ls.SaveLog("Total Scores Executed | ");
        return scores;
    }
}

[Serializable]
public class SaveFile
{
    // Variables
    public List<Scr_QuestSave> sav_qList = new List<Scr_QuestSave>();
    public float sav_gTimes;
    public float sav_scorer;
    public int sav_register;

    // Constructor
    public SaveFile(List<Scr_QuestSave> list, float time, float score, int register)
    {
        sav_qList = list;
        sav_gTimes = time;
        sav_scorer = score;
        sav_register = register;

    }
}