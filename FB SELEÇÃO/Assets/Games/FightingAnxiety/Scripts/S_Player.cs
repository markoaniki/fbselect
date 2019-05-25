using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Player : MonoBehaviour
{
    //Singleton
    public static S_Player play = null;

    // Variables
    private List<GameObject> tempObj = new List<GameObject>();
    public bool isFree = true;
    public GameObject canvas;
    public GameObject obj;
    public string toCall;

    // Start and Update
    void Start()
    {
        if (play == null) play = this;
    }
    void Update()
    {
        int act = 3;
        if (isFree)
        {
            int posit = 0;
            S_QuestGen.qg.GenerateQuestion();
            List<string> answers = new List<string>();
            /*if (S_QuestGen.phase != true) {
                for (int i = 0; i < SaveAndLoadQuestions_FA.sad.act2Question.options.Count; i++)
                {
                    answers.Add(SaveAndLoadQuestions_FA.sad.act2Question.options[i]);
                }
            }
            else
            {*/
                for (int i = 0; i < SaveAndLoadQuestions_FA.sad.actQuestion.options.Count; i++)
                {
                    answers.Add(SaveAndLoadQuestions_FA.sad.actQuestion.options[i]);
                }
            //}
            List<Vector3> oPos = new List<Vector3>();
            oPos.Add(this.transform.position);
            bool locker = false;
            while (answers.Count > 0)
            {
                GameObject temp = Object.Instantiate(obj, new Vector3(this.transform.position.x - 275, this.transform.position.y - 325 + posit, 0), Quaternion.identity) as GameObject;
                temp.transform.SetParent(canvas.transform, false);
                posit += 75;
                tempObj.Add(temp);
                S_OptionButtom buttom = temp.GetComponent<S_OptionButtom>();
                int pos = Random.Range(0, answers.Count);
                if(pos == 0 && locker == false)
                {
                    buttom.correct = true;
                    locker = false;
                }
                buttom.value = answers[pos];
                buttom.action = act--;
                answers.RemoveAt(pos);
            }
        }
    }

    // Destroyer
    public void Destroyer()
    {
        
        GameObject temp = null;
        int a = tempObj.Count - 1;
        while(a >= 0)
        {
            temp = tempObj[a--];
            tempObj.Remove(temp);
            Destroy(temp.gameObject);
        }
        if(S_Config.conf.noquest == S_Config.conf.maxquest)
        {
            SceneManager.LoadScene(toCall, LoadSceneMode.Single);
        }
        isFree = true;
    }

}
