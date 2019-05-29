using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_OptionButtom : MonoBehaviour
{
    [Header("Button variables")]
    public string value;
    public Text text;
    public int action = 0;
    private string ac = "null";
    public bool correct = false;
    [Header("Button Animation")]
    public Image img;
    public SpriteRenderer spRen;
    [Header("Player Trigger Animation")]
    public GameObject player;
    public bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        img.sprite = spRen.sprite;

        switch (action)
        {
            case 00:
                ac = "Atacar ";
                break;
            case 01:
                ac = "Defender ";
                break;
            case 02:
                ac = "Esquivar ";
                break;
            case 03:
                ac = "Usar Item ";
                break;

        }
        text.text = /*ac +*/ value;
    }

    public void ButtonInteract()
    {
        Debug.Log(value.ToString());

        if (S_StateMachine.sm.phaseState == S_StateMachine.PlayerSM.WAITING_ANSWER)
        {
            int latest = S_QuestGen.qg.questions.Count - 1;
            if (correct)
            {
                Debug.Log(SaveAndLoadQuestions_FA.sad.actQuestion.options[0].ToString());
                if (S_Config.conf == null)
                {
                    Debug.Log("is null");
                    return;
                }
                S_Config.conf.scores += 0.33f;
                Debug.Log(S_Config.conf.scores.ToString());
            }
            else
            {
                S_QuestGen.phase = false;
            }

            S_StateMachine.sm.phaseState = S_StateMachine.PlayerSM.ANIMATION_PHASE1;
        }
    }
}
