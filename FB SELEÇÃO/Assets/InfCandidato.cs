using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfCandidato : MonoBehaviour
{
    [Header("Estudante")]
    public Dropdown dList;
    public Text text;
    public Text Nome;
    public Text Data;
    public Text Escola;
    public Text Serie;
    
    [Header("Questão")]
    public List<Text> Resultados = null;
    public Text NotaTotal = null;
    // Start is called before the first frame update
    public void InforChange()
    {
        if (dList.options.Count == 0)
       {
           return;
       }

        Student s = SaveManager.GetStudentsByID(int.Parse(text.text));

        Nome.text = s.Name;
        Data.text = s.BirthDate;
        Escola.text = s.OldSchool;
        Serie.text = s.Grade;

        List<Questao> q = s.Questions;

        float Total = 0;

        for (int i = 0; i < q.Count; i++)
        {
            Total += q[i].HitPercentage;
            Resultados[i].text = "Questão: " + (i+1).ToString() + " | Acertos: " + q[i].HitPercentage.ToString() + " | Situação: ";
            if(q[i].IsDone)
            {
                Resultados[i].text += "Feita";
            }
            else
            {
                Resultados[i].text += "Não Feita";
            }
        }

        NotaTotal.text = "Total: " + (Total/10).ToString();

    }

  
}
