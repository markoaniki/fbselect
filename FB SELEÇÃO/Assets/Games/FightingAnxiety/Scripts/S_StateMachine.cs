using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_StateMachine : MonoBehaviour
{
    [Header("Singleton")]
    public static S_StateMachine sm = null;

    [Header("Audio Files")]
    public AudioSource asource;
    public AudioClip select;
    public AudioClip highlight;
    public AudioClip attackJ;
    public AudioClip attackE;

    [Header("Hit ICON")]
    public GameObject hit;
    public GameObject enemy;
    public Canvas can;

    // States
    public enum PlayerSM
    {
        GENERATE_QUESTION,
        WAITING_ANSWER,
        ANIMATION_PHASE1,
        ANIMATION_DAMAGE,
        ANIMATION_PHASE3,
        ENEMY_PHASE1,
        ENEMY_DAMAGE,
        ENEMY_PHASE3,
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
                    playSound("attackJ");
                    GenHIT("enemy");
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
                    phaseState = PlayerSM.ENEMY_PHASE1;
                }
                
                break;

            // Final Phase
            case (PlayerSM.END):
                S_Player.play.Destroyer();
                break;
        }
    }

    public void GenHIT(string enmyplyr)
    {
        GameObject tempIns = Instantiate<GameObject>(hit);
        tempIns.transform.SetParent(can.transform);
        switch (enmyplyr)
        {
            case "player":
                tempIns.transform.position = transform.position;
                break;
            case "enemy":
                tempIns.transform.position = enemy.transform.position;
                break;
        }
    }

    public void playSound(string nome)
    {
        switch (nome)
        {
            case "highlight":
                asource.clip = highlight;
                asource.volume = 1;
                asource.priority = 0;
                asource.Play();
                break;
            case "select":
                asource.clip = select;
                asource.volume = .25f;
                asource.priority = 0;
                asource.Play();
                break;
            case "attackJ":
                asource.clip = attackJ;
                asource.volume = .5f;
                asource.priority = 0;
                asource.Play();
                break;
            case "attackE":
                asource.clip = attackE;
                asource.volume = .5f;
                asource.priority = 0;
                asource.Play();
                break;
        }
    }
}
