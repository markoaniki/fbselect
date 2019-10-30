using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//script criado para atender a necessidade do texto "carta" ter a formatação adequada.  ^^
public class Scr_ButtonN2 : MonoBehaviour
{
        public string Dica ="";
        public TMP_Text Console;
        public void OnClick()
        {
            Console.text = Dica;
        }

}
