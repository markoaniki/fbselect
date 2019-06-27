using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BC_Configuration : MonoBehaviour
{
    // Singleton
    public static BC_Configuration config = null;

    [Header("Automatic (DO NOT TURN ON)")]
    public bool isAutomatic = false; // NEVER TURN ON... OK?

    [Header("Question Related Variables")]
    public int maxQuest = 10; // Max number of questions
    public int contQuest = 0; // Counter of questions already answered
    public int corQuest = 0; // Counter of questions correctly answered

    [Header("Personal Info Related Variables")]
    public string RegName = "Daniel Augusto da Silva Mendes Filho"; // Name of the student
    public int idCode = 1510518; // Student ID

    // Awake, Start & Update
    void Awake()
    {
        if (config == null) config = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    // Save Archive
    public void SaveFile()
    {
        BC_SavedInfo ts = new BC_SavedInfo(RegName, idCode, corQuest, contQuest);
        string json = JsonUtility.ToJson(ts);
        Directory.CreateDirectory(Application.dataPath + "\\Saves\\" + idCode.ToString() + "\\BookChase");
        File.WriteAllText(Application.dataPath + "\\Saves\\" + idCode.ToString() + "\\BookChase\\" + "BC_SaveFile.json", json);
    }
}

[Serializable]
public class BC_SavedInfo
{
    public string name;
    public int idCode;
    public int corQuest;
    public int contQuest;

    public BC_SavedInfo(string name, int idCode, int corQuest, int contQuest)
    {
        this.name = name;
        this.idCode = idCode;
        this.corQuest = corQuest;
        this.contQuest = contQuest;
    }
}