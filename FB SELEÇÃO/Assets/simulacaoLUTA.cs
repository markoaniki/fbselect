using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EstruturaDeClasses;

public class simulacaoLUTA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string variavel = "penis";
        Monstro Vampiro = new Monstro("Vampirão",11);
        Guerreiro Kakatua = new Guerreiro("Ido",categoria.arqueiro,"Bola de Fogo",10);
        if (Kakatua.ataque()>Vampiro.defesa())
        {
            Debug.Log("Ataque efetivo");
        }else
        {
            Debug.Log("Se fudeu!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
