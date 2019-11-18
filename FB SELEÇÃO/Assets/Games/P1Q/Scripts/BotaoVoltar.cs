using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.SceneManagement;

public class BotaoVoltar : MonoBehaviour
{
    public string PATH = "";
    public void OnClick()
    {
        SceneManager.LoadScene(PATH);
    }


}
