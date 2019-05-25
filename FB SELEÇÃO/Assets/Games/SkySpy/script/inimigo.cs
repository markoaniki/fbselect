using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class inimigo : MonoBehaviour
{

    public GameObject particulaFolha;
    public int velocidade;

    // Start is called before the first frame update
    void Start()
    {
        //permitindo realizar velocidade diferente dos objetos 
        if(velocidade == 0)
        {
            //movimentação automatica
            GetComponent<Rigidbody>().velocity = new Vector3(-4, 0, 0);
        }
        else
        {             
            GetComponent<Rigidbody>().velocity = new Vector3(velocidade, 0, 0);
        }
        

       
    }

    //colisão
    void OnCollisionEnter(Collision collision)
    {
        //particula após destruir objeto
        GameObject folhas = Instantiate(particulaFolha);
        folhas.transform.position = this.transform.position;

        //destruição        
        Destroy(gameObject);                
         
        
    }    

    // Update is called once per frame
    void Update()
    {

        

        //destruição no fim da tela
        if (transform.position.x < -15)
        {
            Destroy(this.gameObject);
        }
    }

    
}
