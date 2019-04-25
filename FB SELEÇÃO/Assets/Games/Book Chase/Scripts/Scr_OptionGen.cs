using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_OptionGen : MonoBehaviour
{
    // Variables
    public List<GameObject> ansList = new List<GameObject>();
    public GameObject sphere = null;
    public float errorMargin = 10f;
    public float minRadius = 2f;
    public int numQuestions = 0;
    public int varMargin = 5;
    public int minVarMar = 3;
    public int maxOfLoops = 60;

    public GameObject minXZ;
    public GameObject maxXZ;

    private Vector3 minPosXZ;
    private Vector3 maxPosXZ;
    private bool nonRepeat = false;


    void Start()
    {
        minPosXZ = minXZ.transform.position;
        maxPosXZ = maxXZ.transform.position;
    }

    void Update()
    {
        if (Scr_Config.conf.isFree)
        {
            if (ansList.Count == 0)
            {
                Scr_OperationGen.ops.question = "Questão " + numQuestions.ToString() + ":";
                Scr_OperationGen.ops.CreateOperation();
                List<float> answers = new List<float>();
                Scr_GameSave.sav.questList.Add(new Scr_QuestSave(Scr_GameSave.sav.register, Scr_Config.conf.scrsPQ));
                LogSave.ls.SaveLog("question added to questList | ");
                answers.Add(Scr_OperationGen.ops.answer.correct);
                LogSave.ls.SaveLog("Corect Answer added | ");
                answers.Add(VerifyGenerate(answers));
                answers.Add(VerifyGenerate(answers));
                List<Vector3> oldPos = new List<Vector3>();
                oldPos.Add(this.transform.position);
                while (answers.Count > 0)
                {
                    Vector3 vec = SpawnPosition(oldPos);
                    oldPos.Add(vec);
                    GameObject temp = Object.Instantiate(sphere, vec, Quaternion.identity);
                    ansList.Add(temp);
                    Scr_Option component = temp.GetComponent<Scr_Option>();
                    int spherePos = Random.Range(0, answers.Count);
                    component.answer = answers[spherePos];
                    answers.RemoveAt(spherePos);
                }
                LogSave.ls.SaveLog("All options spawned | ");
            }
        }
    }

    // Verify & Generate
    public float VerifyGenerate(List<float> answer)
    {
        LogSave.ls.SaveLog("Verifygenerate Started | ");
        bool isRepeated = false;
        float wEx = 0;
        int numOfLoops = 0;

        while (true)
        {
            if (Scr_OperationGen.ops.answer.correct < 6 && Scr_Config.conf.difficulty == false)
            {
                wEx = Scr_Config.conf.RandomNum(Scr_OperationGen.ops.answer.correct + varMargin, Scr_OperationGen.ops.answer.correct + varMargin + (varMargin + 2));
            }
            else
            {
                wEx = Scr_Config.conf.RandomNum(Scr_OperationGen.ops.answer.correct - varMargin, Scr_OperationGen.ops.answer.correct + varMargin);
            }

            foreach (float x in answer)
            {
                if(Mathf.Floor(x) == Mathf.Floor(wEx))
                {
                    isRepeated = true;
                    break;
                }
            }

            if(numOfLoops >= maxOfLoops)
            {
                float temp;
                if (nonRepeat)
                { 
                    temp = Scr_OperationGen.ops.answer.correct + (varMargin + 1);
                }
                else
                {
                    temp = Scr_OperationGen.ops.answer.correct + (varMargin + 2);
                }
                nonRepeat = !nonRepeat;

                wEx = temp;

                break;
            }

            numOfLoops++;
            if (isRepeated) { continue; }
            LogSave.ls.SaveLog("Non Repeated Number Found | ");
            break;
        }

        LogSave.ls.SaveLog("VerifyGenerate Executado | ");
        return wEx;
    }

    // Check if the Distance is Valid
    bool isDistanceValid(Vector3 spawnPos, List<Vector3> oldPos)
    {
        foreach (Vector3 pos in oldPos)
        {
            if (Vector3.Distance(spawnPos, pos) < minRadius) { return false; }
        }
        return true;
    }

    // Spawn position
    public Vector3 SpawnPosition(List<Vector3> oldPos)
    {
        Vector3 newPos = new Vector3(0, 0, 0);
        int i = 0;
        do
        {
            //pode quebrar aqui!!!
            newPos.x = Random.Range(minPosXZ.x, maxPosXZ.x);
            newPos.z = Random.Range(minPosXZ.z, maxPosXZ.z);
            //Debug.Log(newPos);
            i++;
        } while (!isDistanceValid(newPos,oldPos));

        return newPos;
    }

    // Destroy all options if collides
    public void Destroyer()
    {
        GameObject temp = null;
        int a = ansList.Count - 1;
        while (a >= 0)
        {
            temp = ansList[a--];
            ansList.Remove(temp.gameObject);
            Destroy(temp.gameObject);
        }

        Scr_Config.conf.isFree = true;
        LogSave.ls.SaveLog("Destroyer Executado | ");
    }
    public void OnCollisionEnter(Collision collision)
    {
        Scr_Option ao = collision.gameObject.GetComponent<Scr_Option>();

        if(ao.answer == Scr_OperationGen.ops.answer.correct)
        {
            Scr_GameSave.sav.questList[Scr_GameSave.sav.questList.Count - 1].isCorrect = true;
        }

        LogSave.ls.SaveLog("OnCollisionEnter of Scr_OptionGen Executado | ");
        Destroyer();
    }
}
