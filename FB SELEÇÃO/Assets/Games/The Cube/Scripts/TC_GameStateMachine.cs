using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                break;
            case GameSM.DESTROY_AND_SAVE:
                break;
            case GameSM.END:
                break;
        }
    }
}
