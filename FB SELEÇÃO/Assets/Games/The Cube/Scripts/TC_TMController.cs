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
            temp.transform.parent = null;
            temp.GetComponentInChildren<TextMeshPro>().text = tmpl[i].text;
            temp.GetComponentInChildren<TextMeshPro>().transform.rotation = tmpl[i].transform.localRotation;
        }
    }

}
