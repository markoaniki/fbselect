using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LimparCampos : MonoBehaviour
{
    public InputField Nome, EscolaAntiga;
    public Dropdown Dia, Mes, Ano, Serie;
    
    // Start is called before the first frame update
    public void OnClick()
    {
        Nome.text = "";
        EscolaAntiga.text = "";
        Dia.value = 0;
        Mes.value = 0;
        Ano.value = 0;
        Serie.value = 0;
    }

    
}
