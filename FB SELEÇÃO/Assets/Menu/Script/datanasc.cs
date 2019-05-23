using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class datanasc : MonoBehaviour
{
    public InputField text = null;

    public string formatString = "__/__/____";
    public string toPrintString = "";
    string baseNumber = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ValueChangeCheck()
    {
        string rNumber = text.text;
        baseNumber += rNumber[rNumber.Length-1];
        if(formatString.Length-2 > baseNumber.Length)
        {
            toPrintString = "";
            int j = 0;
            for(int i = 0; i < baseNumber.Length; i++)
            {
                if(formatString[i] == '/'){ toPrintString += '/'; }

                toPrintString += baseNumber[i];
                i++;
            }
        }
        //Debug.Log("Value Changed");
        text.text = toPrintString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
