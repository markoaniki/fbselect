using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Calculo : MonoBehaviour
{
    
    public InputField resposta;

    //Criar variáveis X Y Operação Resultado

    int x, y, res;

    char operacao;
    
    char[] operacoesPossiveis = {'+' , '-' , 'x' , '÷'};

    public void criarOperacao(){
        x = Random.Range(0 , 25);
        y = Random.Range(0 , 25);

        operacao = operacoesPossiveis[Random.Range(0 , 4)];

        gameObject.GetComponentInChildren<Text>().text = x + " " + operacao + " " + y;

        //Colocar CASE SWITCH para adicionar os valores da conta na variável RES.

        switch (operacao)
        {
            case '÷':
                res = x / y;
                break;
            case 'x':
                res = x * y;
                break;
            case '-':
                res = x - y;
                break;
            case '+':
                res = x + y;
                break;
            default:
                break;
        }

    }

    


    // int adicao(){
    //     return x+y;
    // }

    // int subtracao(){
    //     if(x >= y && x-y >= 0){
    //         return x-y;
    //     } 
    // }
    // int multiplicacao(){
    //     return x*y;
    // }

    // int divisao(){
    //     return x/y;
    // }

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
