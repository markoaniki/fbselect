using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scr_Button : MonoBehaviour
{
    public string Dica = "Código 1: Dispositivo usado para comunicação pessoal.";
    public TMP_Text Console;
    public void OnClick()
    {
        Console.text = Dica;
    }
}
