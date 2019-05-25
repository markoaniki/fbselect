using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LogSave : MonoBehaviour
{
    // Singleton
    public static LogSave ls = null;
    private LogFile logfile = new LogFile();

    // Start & Update
    void Start()
    {
        if (ls == null)
        {
            ls = this;
        }
    }
    void Update()
    {
        
    }

    public void SaveLog(string log)
    {
        logfile.addLog(log);
        string json = JsonUtility.ToJson(logfile);
        //File.WriteAllText(Application.dataPath + "\\Saves\\BC_LogFile.json", json);
    }
}

[Serializable]
public class LogFile
{
    public List<string> Log = new List<string>();

    public void addLog(string Log)
    {
        this.Log.Add(Log);
    }
}
