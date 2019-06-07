using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FINAL : MonoBehaviour
{
    public void OnClick()
    {
        Palavras.PL.VerificarRespostas();
        
        Questao q = SaveManager.estudanteLogado.inProgressQuestion;
        q.IsDone = true;
        q.HitPercentage = (100.0f * Palavras.PL.resultado) / Palavras.PL.total;
    }
}
