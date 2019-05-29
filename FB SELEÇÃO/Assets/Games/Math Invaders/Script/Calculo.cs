using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Calculo : MonoBehaviour
{

    //Criar variáveis X Y Operação Resultado
    public int min = 0, max = 50;
    
    public Text tela;

    int x, y;

    public int res;

    public bool resetQuestion;

    public bool hasFinished;

    int[] primos = {2, 3, 5, 7};

    char operacao;
    
    char[] operacoesPossiveis = {'+' , '-' , 'x' , '÷'};

    Vector3Int maxNum()
    {
        List<int> usados = new List<int>();
        int res = 1;
        int Last = 1;
        while(true)
        {
            Last = primos[Random.Range(0, primos.Length)];
            res *= Last;

            if(res > max){ break; }
            
            usados.Add(Last);
        }

        res /= Last;

        int n = Random.Range(1, usados.Count);

        int x = 1;

        for(int i = 0; i < n; i++)
        {
            int index = Random.Range(0, usados.Count);
            int temp = usados[index];
            x *= temp;
            usados.RemoveAt(index);
        }

        int y = res/x;
        
        return new Vector3Int(x,y,res);
    }

    public void criarOperacao(){
        operacao = operacoesPossiveis[Random.Range(0 , 4)];

        //Colocar CASE SWITCH para adicionar os valores da conta na variável RES.

        switch (operacao)
        {
            case '÷':
                Vector3Int op12MaxDiv = maxNum();
                res = op12MaxDiv.x;
                x = op12MaxDiv.z;
                y = op12MaxDiv.y;
                break;
            case 'x':
                Vector3Int op12Max = maxNum();
                // Debug.Log(op12Max);
                res = op12Max.z;
                x = op12Max.x;
                y = op12Max.y;
                break;
            case '-':
                x = Random.Range((int)max/2,max);
                y = Random.Range(min, x);
                res = x - y;
                break;
            case '+':
                res = Random.Range((int)max/2,max);
                y = Random.Range(min, res);
                x = res - y;
                break;
            default:
                break;
        }

        tela.text =  x + " " + operacao + " " + y;

        // gameObject.GetComponentInChildren<Text>().text = x + " " + operacao + " " + y;

    }

    



    // Start is called before the first frame update
    void Start()
    {
        hasFinished = false;
        resetQuestion = true;
        criarOperacao();
        // Debug.Log(adicao());
    }

    public void FinishQuestion()
    {
        hasFinished = true;
        tela.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasFinished)
        {
            if(resetQuestion)
            {
                criarOperacao();
                resetQuestion = false;
            }
        }
    }
}
