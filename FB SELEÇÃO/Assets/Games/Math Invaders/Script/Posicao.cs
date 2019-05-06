using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posicao : MonoBehaviour
{
    // Lidar com as colisões - Barreira e Livro
    // Colidiu com a barreira teletransporta pra cima e desabilita o collider da barreira e a sprite da barreia
    // Collidiu com o livro, teletransporta pra cima e desabilita o collider do livro e o sprite do livro
    //Se transpassar 100 y ou menos, teletransporta pra cima

    GameObject camera;
    void Start()
    {
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "barreira"){
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            other.gameObject.GetComponent<Collider2D>().enabled = false;
        }

        if (other.gameObject.tag == "livro"){
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.SetActive(false);
            camera.GetComponent<criarInimigos>().livros++;
            Debug.Log(camera.GetComponent<criarInimigos>().livros);
        }

        // else if (other.gameObject.tag == "inimigo"){
            
        //     Debug.Log("caralhos");

        //     transform.position = new Vector3(transform.position.x , Random.Range(780,1000) , transform.position.z);
            
        //     other.gameObject.transform.position = new Vector3(transform.position.x , Random.Range(780,1000) , transform.position.z);

        //     Debug.Log(other.transform.position);
        // }

        transform.position = new Vector3(transform.position.x,Random.Range(738,1000),transform.position.z);

        GetComponent<Calculo>().criarOperacao();
    } 
    
}
