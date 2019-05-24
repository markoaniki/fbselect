using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfCandidato : MonoBehaviour
{
    public Dropdown dList;
    public Text text;
    public Text Nome;
    public Text Data;
    public Text Escola;
    public Text Serie;
    
    // Start is called before the first frame update
    public void InforChange()
    {
        if (dList.options.Count == 0)
       {
           return;
       }

        Student s = SaveManager.GetStudentsByID(int.Parse(text.text));

        Nome.text = s.Name;
        Data.text = s.BirthTime;
        Escola.text = s.OldSchool;
        Serie.text = s.Grade;
    }

  
}
