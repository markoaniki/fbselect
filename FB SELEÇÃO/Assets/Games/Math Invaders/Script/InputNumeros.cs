using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputNumeros : MonoBehaviour
{
    public List<Calculo> calculos;
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
        foreach (Calculo c in calculos)
        {
            if(c.res == saveNum)
            {
                c.resetQuestion = false;
                Debug.Log("OK!");
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            saveNum = int.Parse(numero.text);
            Debug.Log(saveNum);
            testCalc();
            numero.text="";
            SetInputFieldActive();
        }
    }
}
