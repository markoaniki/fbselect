using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_SaveLoad : MonoBehaviour
{
    // Start & Update
    void Start()
    {
        Scr_GameSave.sav.LoadFile();
    }
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        Scr_GameSave.sav.SaveFile();
    }
}
