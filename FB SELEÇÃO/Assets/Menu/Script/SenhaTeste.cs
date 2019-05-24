using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SenhaTeste : MonoBehaviour
{
    public GameObject canvas3, canvas4;
    public int timeload = 1;
    private const string Login = "admin";
    private const string Pass = "admin";

    [SerializeField]
    private TMP_InputField usuarioField = null;

    [SerializeField]
    private TMP_InputField senhaField = null;

    [SerializeField]
    private Text feedbackmsg = null;

    // private Toggle rememberData = null;

    void Start()
    {
        // userField = usuarioField.GetComponent<Text>();
        // passField = senhaField.GetComponent<Text>();
    }
    
    public void FazerLogin(bool DebugMode){
        
        string usuario;
        string senha;

        if(DebugMode)
        {
            usuario = Login;
            senha = Pass;
        }
        else
        {
            usuario = usuarioField.text;
            senha = senhaField.text;
        }
        
        if(usuario == Login && senha == Pass){
            feedbackmsg.CrossFadeAlpha(100f, 0f, false);
            feedbackmsg.color = Color.green;
            feedbackmsg.text = "Login realizado com sucesso...";
            StartCoroutine(CarregarScene());
        } else
        {
            feedbackmsg.CrossFadeAlpha(100f, 0f, false);
            feedbackmsg.color = Color.red;
            feedbackmsg.text = "Usuário ou Senha inválidos";
            feedbackmsg.CrossFadeAlpha(0f, 2f, false);
            usuarioField.text = "";
            senhaField.text = "";
        }
    }
    
    void Update()
    {
        //Debug.Log(usuarioField.text);
    }
    void OnGUI()
    {
        
    }

    IEnumerator CarregarScene(){
        yield return new WaitForSeconds(timeload);
        usuarioField.text = "";
        senhaField.text = "";
        feedbackmsg.text = "";
        canvas3.SetActive(false);
        canvas4.SetActive(true);
    }
}