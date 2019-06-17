using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_Player : MonoBehaviour
{
    [Header("Singleton")]
    public static S_Player play = null;

    // Variables
    private List<GameObject> tempObj = new List<GameObject>();
    //public bool isFree = true;
    [Header("Objects Needed")]
    public GameObject canvas;
    public GameObject obj;
    public string toCall;
    public Image img;
    

    // Start and Update
    void Start()
    {
        if (play == null) play = this;
    }
    void Update()
    {
        img.transform.SetAsLastSibling();
    }

    // Spawner
    public void CreateQuestion()
    {
        // Variables
        int posit = 0;
        S_QuestGen.qg.GenerateQuestion();
        List<string> answers = new List<string>();
        List<Vector3> oPos = new List<Vector3>();
        bool locker = false;

        // List of possible answers
        for (int i = 0; i < FAA_SnL.sad.actQuestion.options.Count; i++)
        {
            answers.Add(FAA_SnL.sad.actQuestion.options[i]);
        }
        
        // Object position List
        oPos.Add(this.transform.position);
        
        // Instantiate Objects
        while (answers.Count > 0)
        {
            GameObject temp = Object.Instantiate(obj, new Vector3(this.transform.position.x - 275, this.transform.position.y - 325 + posit, 0), Quaternion.identity) as GameObject;
            temp.transform.SetParent(canvas.transform, false);
            posit += 75;
            tempObj.Add(temp);
            S_OptionButtom buttom = temp.GetComponent<S_OptionButtom>();
            int pos = Random.Range(0, answers.Count);
            if (pos == 0 && locker == false)
            {
                buttom.correct = true;
                locker = false;
            }
            buttom.value = answers[pos];;
            answers.RemoveAt(pos);
        }

        // STATE MACHINE: GENERATE_QUESTION --> WAITING ANSWER
        S_StateMachine.sm.phaseState = S_StateMachine.PlayerSM.WAITING_ANSWER;
    }

    // Destroyer
    public void Destroyer()
    {
        // Variables
        GameObject temp = null;
        int a = tempObj.Count - 1;
        
        // Destroy buttons
        while (a >= 0)
        {
            temp = tempObj[a--];
            tempObj.Remove(temp);
            Destroy(temp.gameObject);
        }
        
        // END GAME
        if (S_Config.conf.noquest == S_Config.conf.maxquest)
        {
            SceneManager.LoadScene(toCall, LoadSceneMode.Single);
        }

        // STATE MACHINE: END --> GENERATE_QUESTION 
        S_StateMachine.sm.phaseState = S_StateMachine.PlayerSM.GENERATE_QUESTION;
    }

}
