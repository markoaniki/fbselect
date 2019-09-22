using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInfo : MonoBehaviour
{
    public Text nomeinfo = null;
    public Text questioninfo = null;
    public Text tempoinfo = null;
    // Start is called before the first frame update
    void Start()
    {
        nomeinfo.text = SaveManager.estudanteLogado.Name;

        List<Questao> Questoes = SaveManager.estudanteLogado.Questions;
        int inforQuestion = 0;
        foreach (Questao q in Questoes)
        {
            if (q.IsDone){
                inforQuestion++;
            }
        }
        questioninfo.text = inforQuestion.ToString();

        if (!SaveManager.InQuestion)
        {
            SaveManager.ResetTime();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        SaveManager.estudanteLogado.Time = SaveManager.TimeTest;
        int tempTime = (int)SaveManager.estudanteLogado.Time;
        int min = tempTime / 60;
        int sec = tempTime % 60;
        string minStr = null;
        if(min < 10) {minStr = '0'+min.ToString();}else{minStr = min.ToString();}
        string secStr = null;
        if(sec < 10) {secStr = '0'+sec.ToString();}else{secStr = sec.ToString();}
        tempoinfo.text = minStr + ":" + secStr;
    }
}
