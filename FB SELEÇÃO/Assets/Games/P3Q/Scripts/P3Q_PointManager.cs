using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3Q_PointManager : MonoBehaviour
{
    public static P3Q_PointManager P3Q = null;

    public int TotalPoints = 0;
    public int Points = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(P3Q == null)
        {
            P3Q = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
