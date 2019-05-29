using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_StateMachine : MonoBehaviour
{
    [Header("Singleton")]
    public static S_StateMachine sm = null;

    // States
    public enum PlayerSM
    {
        GENERATE_QUESTION,
        WAITING_ANSWER,
        ANIMATION_PHASE1,
        ANIMATION_DAMAGE,
        ANIMATION_PHASE3,
        END
    }

    [Header("Variables")]
    public PlayerSM phaseState;
    public float distance = .1f;
    public float coolTime = 1f;
    private float cooldown = 0f;

    // Start, Update & Awake
    void Awake()
    {
        phaseState = PlayerSM.GENERATE_QUESTION;
    }
    void Start()
    {
        if (sm == null) sm = this;
    }
    void Update()
    {
        switch (phaseState)
        {
            // Start State
            case (PlayerSM.GENERATE_QUESTION):
                S_Player.play.CreateQuestion();
                break;

            // Waiting for an answer State
            case (PlayerSM.WAITING_ANSWER):
                break;

            // Animation Phases
            case (PlayerSM.ANIMATION_PHASE1):
                // Movimentation Foward
                if (transform.position.x < 0)
                {
                    transform.position += new Vector3(.3f, 0, 0);
                }
                else
                {
                    // Phase Change
                    phaseState = PlayerSM.ANIMATION_DAMAGE;
                }
                
                break;

            case (PlayerSM.ANIMATION_DAMAGE):
                // Phase Change
                if(cooldown < coolTime)
                {
                    cooldown += Time.deltaTime;
                }
                else
                {
                    cooldown = 0f;

                    // Phase Change
                    phaseState = PlayerSM.ANIMATION_PHASE3;
                }
                
                break;

            case (PlayerSM.ANIMATION_PHASE3):
                // Movimentation Backwards
                if (transform.position.x > -5.3f)
                {
                    transform.position -= new Vector3(.3f, 0, 0);
                }
                else
                {
                    // Phase Change
                    phaseState = PlayerSM.END;
                }
                
                break;

            // Final Phase
            case (PlayerSM.END):
                S_Player.play.Destroyer();
                break;
        }
    }
}
