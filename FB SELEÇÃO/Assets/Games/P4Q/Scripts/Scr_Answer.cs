using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Answer : MonoBehaviour
{
    // Singleton
    public static Scr_Answer ans = null;

    [Header("Lista de Botões")]
    public List<GameObject> booty = new List<GameObject>();

    [Header("Pontuação")]
    public int corretos = 0;
    public float nota;

    // Awake, Start e Update
    void Awake()
    {
        if (ans == null) ans = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void OnClick()
    {
        foreach (GameObject b in booty)
        {
            if(b.GetComponent<Scr_Yey>().selected == b.GetComponent<Scr_Yey>().corf)
            {
                corretos++;
            }
        }
        nota = (corretos * 100) / booty.Count;
        Debug.Log(corretos.ToString());
        Debug.Log(nota.ToString());
    }
}
