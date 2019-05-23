using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AddStudent : MonoBehaviour
{
    public InputField Nome, EscolaAntiga;
    public Dropdown Dia, Mes, Ano, Serie;
    public Text feedbackmsg = null;
    string nada = "";
    
    private List<int> GenerateQuestions()
    {
        List<int> Questoes = new List<int>();

        for(int i = 1; i<=10 ; i++)
        {
            Questoes.Add(i);
        }

        return Questoes;
    }

    // Start is called before the first frame update
    public void OnClick()
    {
        Debug.Log("Funcionou carai: " + Nome.text + Dia.options[Dia.value].text);

        if(Nome.text != nada && EscolaAntiga.text != nada){
            feedbackmsg.CrossFadeAlpha(100f, 0f, false);
            feedbackmsg.color = Color.green;
            feedbackmsg.text = "Cadastro realizado com sucesso...";
            feedbackmsg.CrossFadeAlpha(0f, 2f, false);
            string BirthData = Dia.options[Dia.value].text + "/" + Mes.options[Mes.value].text + "/" + Ano.options[Ano.value].text;
            SaveManager.AddStudent(Nome.text,BirthData,EscolaAntiga.text,Serie.options[Serie.value].text,GenerateQuestions());
            Nome.text = nada;
            EscolaAntiga.text = nada;
        } else
        {
            feedbackmsg.CrossFadeAlpha(100f, 0f, false);
            feedbackmsg.color = Color.red;
            feedbackmsg.text = "Preencha todos os campos";
            feedbackmsg.CrossFadeAlpha(0f, 2f, false);
        }


    }

  
}
