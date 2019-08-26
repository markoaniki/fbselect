using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TC_TMController : MonoBehaviour
{
    // Singleton
    public static TC_TMController tmc = null;

    [Header("TextMeshPro List")]
    public List<TextMeshPro> tmpl = new List<TextMeshPro>();

    [Header("Options")]
    public List<GameObject> optSpawn = new List<GameObject>();
    public GameObject optPrefab;
    public List<GameObject> spwndGO = new List<GameObject>();

    [Header("Answer Placements")]
    public List<GameObject> aplace = new List<GameObject>();

    // Awake, Start & Update
    void Awake()
    {
        if (tmc == null) tmc = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void DefineValue()
    {
        List<char> tempChar = TC_NumberGen.ng.RandomGenerate06();
        for(int i = 0; i < tempChar.Count; i++)
        {
            tmpl[i].text = tempChar[i].ToString();
            tmpl[i].gameObject.transform.localRotation = new Quaternion(0f, 0f, Random.Range(0, 4) * 90, 0f);
        }

        SpawnOptions();
    }

    public void SpawnOptions()
    {
        GameObject temp;

        for (int i = 0; i < tmpl.Count; i++)
        {
            temp = Instantiate(optPrefab, optSpawn[i].transform);
            spwndGO.Add(temp);
            temp.transform.parent = null;
            temp.GetComponentInChildren<TextMeshPro>().text = tmpl[i].text;
            Debug.Log(tmpl[i].text);
            temp.GetComponentInChildren<TextMeshPro>().transform.rotation = tmpl[i].transform.localRotation;

        }

        RandomAnswer();
    }

    public void RandomAnswer()
    {
        int j = Random.Range(0, tmpl.Count-1);
        Debug.Log(j.ToString());
        spwndGO[j].GetComponent<TC_OFController>().father = aplace[j].name;
        spwndGO[j].transform.SetParent(aplace[j].transform);
        spwndGO[j].GetComponent<TC_OFController>().origPos = new Vector3(0, 0, 0);
        spwndGO[j].transform.localPosition = spwndGO[j].GetComponent<TC_OFController>().origPos;
    }

    public void OnClick()
    {
        if (TC_GameStateMachine.gsm.ags == TC_GameStateMachine.GameSM.WAITING_ANSWER)
        {
            for (int i = 0; i < spwndGO.Count; i++)
            {
                spwndGO[i].transform.parent = null;
                spwndGO[i].GetComponent<TC_OFController>().father = null;
                spwndGO[i].GetComponent<TC_OFController>().origPos = spwndGO[i].GetComponent<TC_OFController>().origP;
                spwndGO[i].transform.localPosition = spwndGO[i].GetComponent<TC_OFController>().origPos;
            }
        }
    }

    public void ConfirmAnswer()
    {
        if (TC_GameStateMachine.gsm.ags == TC_GameStateMachine.GameSM.WAITING_ANSWER)
        {
            bool AA = false;
            for (int i = 0; i < aplace.Count; i++)
            {
                if (aplace[i].transform.childCount == 0)
                {
                    AA = true;
                    break;
                }
            }

            if (!AA)
            {
                TC_GameStateMachine.gsm.ags = TC_GameStateMachine.GameSM.COMPARING_ANSWER;
            }
        }
    }

    public float CompareAnswer()
    {
        float points = 0;
        for(int i = 0; i < tmpl.Count; i++)
        {
            Debug.Log(tmpl[i].text);
            Debug.Log(aplace[i].GetComponentInChildren<TextMeshPro>().text);
            if (tmpl[i].text.Equals(aplace[i].GetComponentInChildren<TextMeshPro>().text))
            {
                points += .5f;
                Debug.Log(points.ToString());
            }
        }

        return points;
    }
}
