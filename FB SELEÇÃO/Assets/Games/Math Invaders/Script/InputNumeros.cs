using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputNumeros : MonoBehaviour
{

    int saveNum = 0;
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            saveNum = int.Parse(numero.text);
            Debug.Log(saveNum);
            numero.text="";
            SetInputFieldActive();
        }
    }
}
