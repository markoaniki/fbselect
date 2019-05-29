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
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
