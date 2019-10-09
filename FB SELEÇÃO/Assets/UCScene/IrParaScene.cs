using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrParaScene : MonoBehaviour
{
    public string retPath = "";
    public string MapPath = "";
    public int IndexFase = 6;

    public void IrPara()
    {
        Debug.Log("OK");
        SaveManager.estudanteLogado.SetQuestion(IndexFase);
        SaveManager.InQuestion = true;
        SceneManager.LoadScene(retPath, LoadSceneMode.Single);
    }
}
