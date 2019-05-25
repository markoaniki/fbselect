using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CalculoADI : MonoBehaviour
{
    
    public InputField resposta;
    public Text Texto;

    public int minX, maxX, minY, maxY;


    //Criar variáveis X Y Operação Resultado

    int x, y, res;

    public void criarOperacao(){
        x = Random.Range(minX , maxX);
        y = Random.Range(minY , maxY);

        Texto.text = x + " " + "+" + " " + y;

        res = x + y;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        criarOperacao();
        // Debug.Log(adicao());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
