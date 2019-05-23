using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MudarCena2 : MonoBehaviour
{
    public TMP_InputField inscricao = null;
    public Text feedbackmsg;
    public void MudarCenaParaMapa()
    {
        string inscricaoSTR = inscricao.text;
        if (inscricaoSTR.Length == 0)
        {
            feedbackmsg.CrossFadeAlpha(100f, 0f, false);
            feedbackmsg.color = Color.red;
            feedbackmsg.text = "Insira inscrição";
            feedbackmsg.CrossFadeAlpha(0f, 2f, false);
            return;
        }
        
        int inscricaoINT = int.Parse(inscricaoSTR);
        

        if(!SaveManager.SetStudentByID(inscricaoINT))
        {
            feedbackmsg.CrossFadeAlpha(100f, 0f, false);
            feedbackmsg.color = Color.red;
            feedbackmsg.text = "Inscrição não encontrada.";
            feedbackmsg.CrossFadeAlpha(0f, 2f, false);
            return;
        }

        SceneManager.LoadScene("MapaDoJogo");
    }
}