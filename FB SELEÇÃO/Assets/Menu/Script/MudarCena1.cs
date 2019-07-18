using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena1 : MonoBehaviour
{
    public void MudarCenaParaMenu()
    {
        SaveManager.InQuestion = false;
        SceneManager.LoadScene("Menu");
    }
}