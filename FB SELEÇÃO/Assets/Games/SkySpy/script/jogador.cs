﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogador : MonoBehaviour
{
    bool comecou;
    bool acabou = false;
    Rigidbody2D corpoJogador;
    public Vector2 forcaImpulso = new Vector2(0, 500f);
    public GameObject particulaFolha;

    // Start is called before the first frame update
    void Start(){
        corpoJogador = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {
        if (!acabou)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!comecou)
                {
                    comecou = true;
                    corpoJogador.isKinematic = false;
                }
                corpoJogador.velocity = new Vector2(0, 0);
                corpoJogador.AddForce(forcaImpulso);

                GameObject folhas = Instantiate(particulaFolha);
                folhas.transform.position = this.transform.position;
            }
            float alturaFelpudoEmPixels = Camera.main.WorldToScreenPoint(transform.position).y;
            if (alturaFelpudoEmPixels > Screen.height || alturaFelpudoEmPixels < 0)
            {
                Destroy(this.gameObject);
            }
            transform.rotation = Quaternion.Euler(0, 0, corpoJogador.velocity.y * 3);
        }
    }
    void OnCollisionEnter2D()
        {
            if (!acabou)
            {
                acabou = true;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 0));
                GetComponent<Rigidbody2D>().AddTorque(300f);
                Debug.Log("corno");
            }
        }

    
}
