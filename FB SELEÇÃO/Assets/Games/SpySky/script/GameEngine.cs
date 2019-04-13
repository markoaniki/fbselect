using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    
    public static GameEngine GE = null;
    public List<GameObject> Inimigo;
    // Start is called before the first frame update

        //void que inicializa antes do start
    void Awake()
    {
        
        //armazenamento da primeira gameEngine criada
        //permite o acesso a primeira instancia de classe, desta classe, por qualquer outro script
        if (GE == null)
        {
         GE = this;
         InvokeRepeating("CriaInimigo", 1.0f, 1.5f); 
        }
        
    }

    void Start()
    {
        

        if (GE == null)
        {
          GE = this;
          InvokeRepeating("CriaInimigo", 1.0f, 1.5f);   
        }
   
    }



    void Acabou()
    {
        CancelInvoke("CriaInimigo");
    }

    void CriaInimigo()
    {
       
            float alturaAleatoria = 6f * Random.value - 3f;

            int iniPos = Random.Range(0, Inimigo.Count);
            
            GameObject novoInimigo = Instantiate(Inimigo[iniPos]);
            novoInimigo.transform.position = new Vector2(15f, alturaAleatoria);
    }
}

