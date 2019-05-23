using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class dataNascTeste : MonoBehaviour
{   
    public Dropdown dList;

    public int min = 1;
    public int max = 31;
     private void Awake()
     {
        for(int i = min; i <= max; i++){
            Dropdown.OptionData data = new Dropdown.OptionData();
            data.text = i.ToString();
            dList.options.Add(data);
        }
     }

 }
