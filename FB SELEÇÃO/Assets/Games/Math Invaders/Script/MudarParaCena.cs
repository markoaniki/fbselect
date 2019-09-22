using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarParaCena : MonoBehaviour
{
    public string Cena;

    public void MudarCenaParaMenu()
    {
        SceneManager.LoadScene(Cena);
    }
}