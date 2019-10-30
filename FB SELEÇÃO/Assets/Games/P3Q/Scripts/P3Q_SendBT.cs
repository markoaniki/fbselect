using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P3Q_SendBT : MonoBehaviour
{
    public string PATH = "";
    public float cooldDownToNext = 1.0f;
    private bool goNext = false;
    private float counter = 0;

    public GameObject toDeactivate = null;
    public GameObject toActivate = null;
    public bool isLast = false;

    public List<ChangeImage> toChangeList = null;

    public void OnClick()
    {
        foreach(ChangeImage CI in toChangeList)
        {
            CI.SpriteChange();
        }

        goNext = true;
        counter = 0;
    }

    private void NotLast()
    {
        toActivate.SetActive(true);
        toDeactivate.SetActive(false);
    }

    private void Last()
    {
        //SALVAMENTO DE PONTUAÇÃO
        Questao q = SaveManager.estudanteLogado.inProgressQuestion;
        q.IsDone = true;
        q.HitPercentage = (100.0f *P3Q_PointManager.P3Q.Points) / P3Q_PointManager.P3Q.TotalPoints;

        Debug.Log("Salvou Pontuação");
        Debug.Log(P3Q_PointManager.P3Q.Points + "/" + P3Q_PointManager.P3Q.TotalPoints);

        //SceneManager.LoadScene(PATH, LoadSceneMode.Single);
        UnityEngine.SceneManagement.SceneManager.LoadScene(PATH);

        Debug.Log("É para mudar a cena!!!");

    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (goNext && counter > cooldDownToNext)
        {
            if (!isLast) { NotLast(); } else { Last(); }         
        }
    }
}
