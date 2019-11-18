using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Q_PointCounter : MonoBehaviour
{
    public List<P1Q_ChangeImage> OptionsList = null;
    public bool isLast = false;

    public void OnCLick()
    {
        foreach(P1Q_ChangeImage CI in OptionsList)
        {
            P1Q_PointManager.P1Q.TotalPoints++;
            if (CI.DidItHit()) { P1Q_PointManager.P1Q.Points++; }
        }
    }
}
