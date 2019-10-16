using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scr_ButtonFull : MonoBehaviour
{
    
    public string Dica1 = "";
    public string Dica2 = "";
    public string Dica3 = "";
    public string Dica4 = "";
    public string Dica5 = "";
    public string Dica6 = "";
    public string Dica7 = "";
    public string Dica8 = "";
    public string Dica9 = "";
    public string Dica10 = "";
    public TMP_Text Console1;
    public TMP_Text Console2;
    public TMP_Text Console3;
    public TMP_Text Console4;
    public TMP_Text Console5;
    public TMP_Text Console6;
    public TMP_Text Console7;
    public TMP_Text Console8;
    public TMP_Text Console9;
    public TMP_Text Console10;
    public void OnClick()
    {
        Console1.text = Dica1;
        Console2.text = Dica2;
        Console3.text = Dica3;
        Console4.text = Dica4;
        Console5.text = Dica5;
        Console6.text = Dica6;
        Console7.text = Dica7;
        Console8.text = Dica8;
        Console9.text = Dica9;
        Console10.text = Dica10;
    }

    
}
