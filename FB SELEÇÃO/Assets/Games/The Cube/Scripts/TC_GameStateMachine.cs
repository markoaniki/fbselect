using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TC_GameStateMachine : MonoBehaviour
{
    //Slingleton
    public static TC_GameStateMachine gsm = null; /*Game State Machine*/

    //StateMachine
    public enum GameSM
    {
        START, /*Initialization*/
        GENERATE_QUESTION, /*Read questions on the server or archive and generate in game*/
        WAITING_ANSWER, /*Player Input*/
        COMPARING_ANSWER, /*Check player answer with correct answer on the server or archive*/
        DESTROY_AND_SAVE, /*Destroy options objects and save results*/
        END /*End game if there are no more questions to answer, else retrun to GENERATE_QUESTIONS */
    }

    [Header("Actual GameState")]
    public GameSM ags; /*Actual Game State*/

    [Header("ENDGAME Scene")]
    public string toCall;

    [Header("SavedFiles")]
    public float nota;
    public int matricula;
    public string nome;

    // Awake, Start & Update
    void Awake()
    {
        if (gsm == null) gsm = this;
        ags = GameSM.START;
    }
    void Start()
    {

    }
    void Update()
    {
        switch (ags)
        {
            case GameSM.START:
                ags = GameSM.GENERATE_QUESTION;
                break;
            case GameSM.GENERATE_QUESTION:
                TC_TMController.tmc.DefineValue();
                ags = GameSM.WAITING_ANSWER;
                break;
            case GameSM.WAITING_ANSWER:
                break;
            case GameSM.COMPARING_ANSWER:
                TC_TMController.tmc.CompareAnswer();
                ags = GameSM.DESTROY_AND_SAVE;
                break;
            case GameSM.DESTROY_AND_SAVE:
                TC_SaveFile sf = new TC_SaveFile(nota, matricula, nome);
                string json = JsonUtility.ToJson(sf);
                Directory.CreateDirectory(Application.dataPath + "\\Saves\\" + matricula.ToString() + "\\TheCube");
                File.WriteAllText(Application.dataPath + "\\Saves\\" + matricula.ToString() + "\\TheCube\\" + "TC_SaveFile.json", json);
                ags = GameSM.END;
                break;
            case GameSM.END:
                /*SceneManager.LoadScene(toCall, LoadSceneMode.Single);*/
                break;
        }
    }
}
[Serializable]
public class TC_SaveFile
{
    public float nota;
    public int matricula;
    public string nome;

    public TC_SaveFile (float nota, int matricula, string nome)
    {
        this.nota = nota;
        this.matricula = matricula;
        this.nome = nome;
    }
}
