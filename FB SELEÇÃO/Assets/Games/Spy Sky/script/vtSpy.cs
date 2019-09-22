using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vtSpy : MonoBehaviour
{
    public string retPath = "";

    public void Return()
    {
        Questao q = SaveManager.estudanteLogado.inProgressQuestion;
        q.IsDone = true;
        q.HitPercentage = (100.0f * JogadorFB.jFB.pontos) / (JogadorFB.jFB.pontos + JogadorFB.jFB.negativo);

        SceneManager.LoadScene(retPath, LoadSceneMode.Single);
    }
}
