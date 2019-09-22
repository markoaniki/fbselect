using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBala : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        position.y += speed * Time.deltaTime;

        transform.position = position;
    }
}