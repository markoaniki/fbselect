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
    public void SetInputFieldActive (){
        EventSystem.current.SetSelectedGameObject(numero.gameObject, null);
        numero.ActivateInputField();  
    }
    // Start is called before the first frame update
    void Start()
    {
        SetInputFieldActive();  
    }

    void testCalc()
    {
        for (int i = 0; i < calculos.Count; i++)
        {
            if(calculos[i].res == saveNum)
            {
                //atirar bala do Transform i
                Instantiate(bala, Shooters[i].position, Quaternion.identity);
                calculos[i].resetQuestion = true;
                Debug.Log("OK!");
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
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
