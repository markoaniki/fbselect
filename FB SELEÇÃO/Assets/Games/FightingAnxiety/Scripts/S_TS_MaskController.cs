using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TS_MaskController : MonoBehaviour
{
    public GameObject sLeft = null;
    public GameObject sRight = null;
    private Renderer rend;
    float scrollSpeed = -0.05f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rend = sLeft.GetComponent<Renderer>();

        if (sLeft != null)
        {
            float offset = Time.time * scrollSpeed;
            rend.material.mainTextureOffset = new Vector2(offset, 0);
        }
        if(sRight != null)
        {
            
        }
    }
}
