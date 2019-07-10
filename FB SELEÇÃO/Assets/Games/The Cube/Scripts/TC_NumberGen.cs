using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TC_NumberGen : MonoBehaviour
{
    // Singleton
    public static TC_NumberGen ng = null;

    private List<int> valHist = new List<int>();

    // Awake, Start & Update
    void Awake()
    {
        if (ng == null) ng = this;
    }
    void Start()
    {
        
    }
    void Update()
    {

    }

    public char RandomGenerate01()
    {
        int ran = Random.Range(0, 35);

        if (valHist.Count >= 35) return '-';
        while (valHist.Contains(ran))
        {
            ran++;
            if (ran > 34) ran = 0;
        }

        valHist.Add(ran);

        if (ran < 9)
        {
            return ran.ToString()[0];
        }

        ran = 65 + ran - 9;

        return System.Convert.ToChar(ran);
    }

    public List<char> RandomGenerate06()
    {
        List<char> lis = new List<char>();

        for(int i = 0; i < 6; i++)
        {
            lis.Add(RandomGenerate01());
        }

        return lis;
    }
}
