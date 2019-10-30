using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scr_CanvasOpener : MonoBehaviour
{
    public GameObject canvas;

    public void OpenPanel()
    {
        if(canvas != null)
        {
            canvas.SetActive(true);
        }
    }
}
