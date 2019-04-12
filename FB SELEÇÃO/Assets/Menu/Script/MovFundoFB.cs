using UnityEngine;
using System.Collections;

public class MovFundoFB : MonoBehaviour
{

    private Material currentMaterial;
    public float speed;
    private float offset;


    // Use this for initialization
    void Start()
    {
        currentMaterial = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        offset += 0.001f;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(this.offset * this.speed, 0));

    }



}