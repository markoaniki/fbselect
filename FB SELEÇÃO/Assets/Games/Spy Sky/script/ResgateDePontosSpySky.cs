using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResgateDePontosSpySky : MonoBehaviour
{

    public int In, In2 ;
    
    public void resgatar()
    {
        Questao q = SaveManager.estudanteLogado.inProgressQuestion;
        q.IsDone = true;
        q.HitPercentage = (100.0f * In) / In2;
        Time.timeScale = 1;
    }
}
