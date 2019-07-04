using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputNumeros : MonoBehaviour
{
    public List<Calculo> calculos;
    public List<Transform> Shooters;
    public GameObject bala = null;
    static public int saveNum = 0;
    public InputField numero;
    public int acertos = 0;
    public int TotalDeContas = 8;
    int contas;
    public Canvas MensagemFinal;
    int r;
    int r2;
    public void SetInputFieldActive ()
    {
        if(Time.timeScale != 0) 
        {
            EventSystem.current.SetSelectedGameObject(numero.gameObject, null);
            numero.ActivateInputField();  
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        contas = TotalDeContas;
        SetInputFieldActive();  
    }

    void testCalc()
    {
        contas--;
        for (int i = 0; i < calculos.Count; i++)
        {
            if(calculos[i].res == saveNum && !calculos[i].hasFinished)
            {
                //atirar bala do Transform i
                acertos++;
                Instantiate(bala, Shooters[i].position, Quaternion.identity);
                calculos[i].resetQuestion = true;
                Debug.Log("OK! ACERTOU!");
                r2=0;
                return;
            }else{
                r2++;
            }
        }        
        //Se der bug, poderá ser o calculos.Count que esteja randomizando de 0 à 4, verifique!!!
        if(r2==calculos.Count){
            r=Random.Range(0,calculos.Count);
            Debug.Log(calculos.Count);
            Instantiate(bala, Shooters[r].position, Quaternion.identity);
            calculos[r].resetQuestion = true;
            Debug.Log("OK! ERROU!");
            r2=0;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(contas == 0)
        {
        //Fim De Jogo
        Debug.Log("Fim De Jogo");
        Debug.Log(acertos);
        Time.timeScale = 0;
        MensagemFinal.GetComponent<Canvas>().enabled = true;
        }
       
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            string tx = numero.text;
            //Debug.Log(tx);
            saveNum = int.Parse(tx);
            //Debug.Log(saveNum);
            testCalc();
            numero.text="";
            SetInputFieldActive();
        }
    }
}
