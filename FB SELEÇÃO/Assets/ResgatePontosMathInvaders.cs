using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResgatePontosMathInvaders : MonoBehaviour
{

    public InputNumeros In = null;
    
    public void resgatar()
    {
        Questao q = SaveManager.estudanteLogado.inProgressQuestion;
        q.IsDone = true;
        q.HitPercentage = (100.0f * In.acertos) / In.TotalDeContas;
        Time.timeScale = 1;
    }
}
