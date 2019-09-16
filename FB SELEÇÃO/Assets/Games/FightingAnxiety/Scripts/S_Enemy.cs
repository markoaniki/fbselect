using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Enemy : MonoBehaviour
{
    [Header("Variables")]
    public float coolTime = 0f;
    private float cooldown = 0f;
    public float distance = 2.5f;

    // Awake, Start & Update
    void Start()
    {
        
    }
    void Update()
    {
        switch (S_StateMachine.sm.phaseState)
        {
            case (S_StateMachine.PlayerSM.ENEMY_PHASE1):
                if (transform.position.x > -2.3f)
                {
                    transform.position -= new Vector3(.3f, 0, 0);
                }
                else
                {
                    S_StateMachine.sm.playSound("attackE");
                    S_StateMachine.sm.GenHIT("player");
                    // Phase Change
                    S_StateMachine.sm.phaseState = S_StateMachine.PlayerSM.ENEMY_DAMAGE;
                }

                break;

            case (S_StateMachine.PlayerSM.ENEMY_DAMAGE):
                if (cooldown < coolTime)
                {
                    cooldown += Time.deltaTime;
                }
                else
                {
                    cooldown = 0f;
                    // Phase Change
                    S_StateMachine.sm.phaseState = S_StateMachine.PlayerSM.ENEMY_PHASE3;
                }

                break;

            case (S_StateMachine.PlayerSM.ENEMY_PHASE3):
                if (transform.position.x < 2.6f)
                {
                    transform.position += new Vector3(.3f, 0, 0);
                }
                else
                {
                    // Phase Change
                    S_StateMachine.sm.phaseState = S_StateMachine.PlayerSM.END;
                }

                break;
        }
    }
}
