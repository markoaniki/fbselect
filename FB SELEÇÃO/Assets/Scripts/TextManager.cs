using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public List<string> Textos = new List<string>();
    public Text textoAtual;
    private int index = -1;
    // Start is called before the first frame update
    void Start()
    {
        passarTexto();
    }

    public void tutorial()
    {
        index = -1;
        passarTexto();
        gameObject.SetActive(true);
    }     
    

    void passarTexto()
    {
       
            index++;
            if (!(index < Textos.Count))
            {
                gameObject.SetActive(false);
                return;
            }
            Debug.Log(Textos.Count);
            textoAtual.text = Textos[index];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            passarTexto();
        }
    }
}
