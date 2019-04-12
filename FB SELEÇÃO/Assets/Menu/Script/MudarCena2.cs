using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena2 : MonoBehaviour
{
    public void MudarCenaParaMapa()
    {
        SceneManager.LoadScene("MapaDoJogo");
    }
}