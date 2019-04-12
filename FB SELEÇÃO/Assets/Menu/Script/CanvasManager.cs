using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    int canvasAtivo = 1;

    public GameObject canvas1, canvas2, canvas3;

    private void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
    }

}