﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3Q_PointCounter : MonoBehaviour
{
    public List<ChangeImage> OptionsList = null;
    public bool isLast = false;

    public void OnCLick()
    {
        foreach(ChangeImage CI in OptionsList)
        {
            P3Q_PointManager.P3Q.TotalPoints++;
            if (CI.DidItHit()) { P3Q_PointManager.P3Q.Points++; }
        }
    }
}
