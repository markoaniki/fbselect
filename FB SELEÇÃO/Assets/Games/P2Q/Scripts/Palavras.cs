using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Palavras : MonoBehaviour
{
    public static Palavras PL = null;
    public int resultado = 0;
    public int total = 0;    
    public List<Text> PLs = null;
    public List<string> PLCorrects = null;
    public List<InputField> Res = null;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PL == null){
            PL = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < PLs.Count; i++)
        {
            if (Res[i].text == "")
            {
                PLs[i].text = "**********";
            }
            else
            {
                PLs[i].text = Res[i].text;
            }
        }       
    }

    public void VerificarRespostas()
    {
        for(int i = 0; i < PLs.Count; i++)
        {
            total++;
            if(Res[i].text == PLCorrects[i])
            {
                resultado++;
            }
        }
    }
}
