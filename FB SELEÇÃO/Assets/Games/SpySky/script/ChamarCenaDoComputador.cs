﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamarCenaDoComputador : MonoBehaviour
{
    public string scene;
    public AudioClip somScena;
    // Start is called before the first frame update 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChamaTelaDoPC()
    {   

        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        GetComponent<AudioSource>().PlayOneShot(somScena);
    }
}
