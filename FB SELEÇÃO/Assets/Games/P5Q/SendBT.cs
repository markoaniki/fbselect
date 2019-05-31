﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendBT : MonoBehaviour
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
        Questao q = SaveManager.estudanteLogado.inProgressQuestion;
        q.IsDone = true;
        q.HitPercentage = (100.0f *P5Q_PointManager.P5Q.Points) / P5Q_PointManager.P5Q.TotalPoints;
        
        SceneManager.LoadScene(PATH, LoadSceneMode.Single);
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
