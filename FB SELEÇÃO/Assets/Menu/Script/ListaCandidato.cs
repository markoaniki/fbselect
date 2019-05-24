using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListaCandidato : MonoBehaviour
{
    
    public Dropdown dList;

    public Text text;

    public InfCandidato IC;    
    
    // Start is called before the first frame update
    public void LoadStudents()
    {
        
        List <Student> Students = SaveManager.GetAllStudents();

        dList.options.Clear();

        foreach(Student s in Students){
           Dropdown.OptionData data = new Dropdown.OptionData();
           data.text = s.Inscription.ToString();
           dList.options.Add(data);
        }

       if (dList.options.Count != 0)
       {
           text.text = dList.options[0].text;
           IC.InforChange();
       }
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
