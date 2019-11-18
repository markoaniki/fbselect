using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Q_PointManager : MonoBehaviour
{
    public static P1Q_PointManager P1Q = null;

    public int TotalPoints = 0;
    public int Points = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(P1Q == null)
        {
            P1Q = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
