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
    }

    public void MudaCanvas()
    {
        switch (canvasAtivo)
        {
            case 1:
                canvasAtivo = 2;
                canvas3.SetActive(false);
                canvas2.SetActive(true);
                canvas1.SetActive(false);
                break;
            case 2:
                canvasAtivo = 1;
                canvas3.SetActive(false);
                canvas2.SetActive(false);
                canvas1.SetActive(true);
                break;
            case 3:
                canvasAtivo = 3;
                canvas3.SetActive(true);
                canvas2.SetActive(false);
                canvas1.SetActive(false);
                break;
        }   
    }
}