using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JogadorFB2 : MonoBehaviour
{
    public KeyCode Up = KeyCode.UpArrow;
    public KeyCode Down = KeyCode.DownArrow;

    //criação de lista baseada nas tag dos objetos encontradas na gameEngine
    private  List<string> listaDePalavras = new List<string>();

    public Text palavra;
    private string palavraAtual,teste;
    public float speed = 1.0f;
    public Text pontuacao;
    public Text pontuacaoNegativa;
    private int pontos,negativo;
    public Text Final;
    public int Fim,som;
    public int PontosFim;
    public float tempo, somSobeOn = 0, somSobeOff = 0;
    private Quaternion rotIni;
    public float rotLimit = 1;

    public AudioClip somSubir;
    public AudioClip somDescer;
    public AudioClip somFim;


    GameObject gameengine;

    // public GameObject particulaFolha;

    bool MaxUp = false;
    bool MaxDown = false;

    // Start is called before the first frame update
    void Start()
    {


        //parar criação de enemigo quando aparecer que você venceu
        gameengine = GameObject.FindGameObjectWithTag("MainCamera");
 
        pontos = 0;
        negativo = 0;       

        //criação da lista com as palavras.
        foreach(GameObject ini in GameEngine.GE.Inimigo)
        {
            listaDePalavras.Add(ini.tag);
        }
        AtualizarAtual();
        rotIni = transform.rotation;
    }

    //atualização da lista após pegar obejto correto
    void AtualizarAtual()
    {
        Debug.Log(listaDePalavras.Count);
        palavraAtual = listaDePalavras[Random.Range(0, listaDePalavras.Count)];
        palavra.text = palavraAtual;

        
    }

    //Limite movimento da tela
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MaxUp")
        {
            MaxUp = true;
            return;
        }
        if (collision.gameObject.tag == "MaxDown")
        {
            MaxDown = true;
            return;
        }

        //pontuação
        if (negativo != PontosFim)
        {
            teste = palavraAtual;
            if (collision.gameObject.CompareTag(palavraAtual))
            {
                AtualizarAtual();
                // pontos = pontos + 1;
                pontos++;
                pontuacao.text = "Pontuação:  " + pontos;
                
                
                while (palavraAtual == teste)
                {
                    AtualizarAtual();

                    while (palavraAtual != teste)
                    {
                        break;
                    }
                }
                                    
                return;
            }
            // else
            // {
            //     //marcação dos ERROS cometidos
            //     negativo = negativo + 100;
                
            //     return;
            // }
        }
    }

    void FimDeJogo()
    {
        if (negativo == PontosFim)
        {
            if (som == 0)
            {
                GetComponent<AudioSource>().PlayOneShot(somFim);
                som++;
            }
            gameengine.SendMessage("Acabou");
            Final.text = "Fim de jogo! Pressione voltar.";

            //verificação se apertou a tecla enter para voltar ao inicio
            if (Input.inputString != "")
            {
                if ((int)(Input.inputString[0]) == 13)
                {
                    
                    Application.LoadLevel("Menu");
                    
                }
            
            }
            
        }
    }

   // void RecarregarCena()
   // {
               
   // }
 

    void Move()
    {
        
        //movimentação para cima
        if (Input.GetKey(Up) && MaxUp == false)
        {
            
            Vector2 position = transform.position;
            position.y += speed * Time.deltaTime;
            transform.position = position;

            if (somSobeOn == 0)
            {
                GetComponent<AudioSource>().PlayOneShot(somSubir);
                somSobeOn=1;
                somSobeOff=0;
            }
            else if(somSobeOn==tempo)
            {
                somSobeOn = 0;
            }
            else
            {
                somSobeOn++;
            }
            //inclinação do personagem para cima
            Quaternion rot = transform.rotation;
            rot.z += Time.deltaTime * 1;

            if (rotIni.z + rotLimit < rot.z)
            {
                rot.z = rotIni.z + rotLimit;
            }

            transform.rotation = rot;
            
            

            MaxDown = false;
        }


        //movimentação para baixo
        if (Input.GetKey(Down) && MaxDown == false)
        {
            Vector2 position = transform.position;
            position.y -= speed * Time.deltaTime;
            transform.position = position;

            if (somSobeOff == 0)
            {
                GetComponent<AudioSource>().PlayOneShot(somDescer);
                somSobeOn = 0;
                somSobeOff = 1;
            }
            else if (somSobeOff == tempo)
            {
                somSobeOff = 0;
            }
            else
            {
                somSobeOff++;
            }


            //inclinação para baixo
            Quaternion rot = transform.rotation;
            rot.z += Time.deltaTime * -1;

            if (rotIni.z - rotLimit > rot.z)
            {
                rot.z = rotIni.z - rotLimit;
            }
            transform.rotation = rot;

            MaxUp = false;
        }

        if(!Input.GetKey(Up) && !Input.GetKey(Down))
        {
            transform.rotation = rotIni;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FimDeJogo();
        Move();
    }

   

}
