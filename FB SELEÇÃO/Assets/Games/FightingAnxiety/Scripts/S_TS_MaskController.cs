using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TS_MaskController : MonoBehaviour
{
    public GameObject sLeft = null;
    public GameObject sRight = null;
    // Start is called before the first frame update
    void Start()
    {
       //if (sLeft == null) transform.GetChild(transform.GetChildCount()-1);
    }

    // Update is called once per frame
    void Update()
    {
        if(sLeft != null)
        {
            sLeft.GetComponent<SpriteRenderer>().size += new Vector2(.01f,.01f);
            sLeft.transform.position += new Vector3(.01f,0,0);
        }
        if(sRight != null)
        {
            
        }
    }
}
