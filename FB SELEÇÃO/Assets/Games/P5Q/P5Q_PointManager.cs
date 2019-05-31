using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P5Q_PointManager : MonoBehaviour
{
    public static P5Q_PointManager P5Q = null;

    public int TotalPoints = 0;
    public int Points = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(P5Q == null)
        {
            P5Q = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
