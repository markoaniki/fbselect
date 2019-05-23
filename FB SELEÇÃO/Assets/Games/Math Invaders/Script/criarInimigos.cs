using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criarInimigos : MonoBehaviour
{
    public int livros = 0;
    
    [Range(780, 1500)]
    public int yMinValue;
    [Range(780, 1500)]
    public int yMaxValue;
    public int numeroEnemy;
    int ypos = 740;
    int[] posicoes = {287, 422, 721, 856};
    public GameObject[] inimigos;

    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < numeroEnemy; i++)
       {
            GameObject a = Instantiate (inimigos[Random.Range(0, 4)]);
            a.transform.position = new Vector2(posicoes[i], Random.Range(yMinValue, yMaxValue));
       }

       

    }
    
    //Criar inimigo apenas no X que ainda tiver livros.

    // Update is called once per frame
    void Update()
    {
        if (livros >= 4){
            Debug.Log("GameOver");
        }
    }
}
