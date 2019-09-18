using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BC_StateMachine : MonoBehaviour
{
    // Singleton
    public static BC_StateMachine sm = null;

    // State Machine
    public enum StateMachine
    {
        START,
        GENERATE_QUESTIONS,
        WAITING_ANSWER,
        SAVING_ANSWER,
        DESTROY_OBJECTS,
        END
    }

    [Header("Actutal State")]
    public StateMachine gameState;

    [Header("ENDGAME Scene")]
    public string toCall;

    // Awake, Start & Update
    void Awake()
    {
        if (sm == null) sm = this;
        gameState = StateMachine.START;
    }
    void Start()
    {
        
    }
    void Update()
    {
        switch (gameState)
        {
            case (StateMachine.START):
                //Change State
                    // START -> GENERATE_QUESTIONS
                gameState = StateMachine.GENERATE_QUESTIONS;
                break;

            case (StateMachine.GENERATE_QUESTIONS):
                // Actions
                BC_OptionsSpawner.os.CreateOperation();

                //Change State
                    // GENERATE_QUESTIONS -> WAITING_ANSWER
                gameState = StateMachine.WAITING_ANSWER;
                break;

            case (StateMachine.WAITING_ANSWER):
                //Change State
                    // WAITING_ANSWER -> SAVING_ANSWER on BC_Player.cs
                break;

            case (StateMachine.SAVING_ANSWER):
                // Actions
                BC_Configuration.config.SaveFile();

                // Change State
                    // SAVING_ANSWER -> DESTROY_OBJECTS
                gameState = StateMachine.DESTROY_OBJECTS;
                break;

            case (StateMachine.DESTROY_OBJECTS):
                // Actions
                BC_OptionsSpawner.os.Destroyer();
                
                // Change State
                    // DESTROY_OBJECTS -> END
                gameState = StateMachine.END;
                break;
                
            case (StateMachine.END):
                if (BC_Configuration.config.contQuest >= BC_Configuration.config.maxQuest)
                {
                    if(BC_Configuration.config.maxQuest >= BC_Configuration.config.contQuest)
                    {

                        Questao q = SaveManager.estudanteLogado.inProgressQuestion;
                        q.IsDone = true;
                        q.HitPercentage = (100.0f * BC_Configuration.config.corQuest) / BC_Configuration.config.maxQuest;
                        Time.timeScale = 1;

                        SceneManager.LoadScene(toCall, LoadSceneMode.Single);
                    }
                }
                else
                {
                    // END -> START
                    gameState = StateMachine.START;
                }
                break;
        }
    }
}
