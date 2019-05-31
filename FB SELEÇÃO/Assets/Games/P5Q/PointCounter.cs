using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public List<ChangeImage> OptionsList = null;
    public bool isLast = false;

    public void OnCLick()
    {
        foreach(ChangeImage CI in OptionsList)
        {
            P5Q_PointManager.P5Q.TotalPoints++;
            if (CI.DidItHit()) { P5Q_PointManager.P5Q.Points++; }
        }
    }
}
