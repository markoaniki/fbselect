using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerCanvasLista : MonoBehaviour
{
    
    // public GameObject Lista, Cadastro;
    public Text TextoMSG;

    public void OnClick()
    {
        // Lista.SetActive(false);
        // Cadastro.SetActive(false);
        TextoMSG.text = "";
    }

}
