using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrParaScene : MonoBehaviour
{
    public string retPath = "";
    public string MapPath = "";

    public void IrPara()
    {
        Debug.Log("OK");

        SceneManager.LoadScene(retPath, LoadSceneMode.Single);
    }
}
