using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    int canvasAtivo = 1;

    public GameObject canvas1, canvas2, canvas3, canvas4, Lista, Cadastro;

    private void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
        Lista.SetActive(false);
        Cadastro.SetActive(false);
    }

}