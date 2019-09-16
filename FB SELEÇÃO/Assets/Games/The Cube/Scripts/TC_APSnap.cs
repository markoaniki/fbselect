using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TC_APSnap : MonoBehaviour
{
    [Header("Answered Object")]
    public bool answrd = false;

    [Header("Collision object prefab")]
    public GameObject prefab = null;

    // Awake, Start & Update
    void Start()
    {
        
    }
    void Update()
    {
        if(transform.childCount < 1)
        {
            answrd = false;
        } else answrd = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(answrd == false && collision.gameObject.GetComponent<TC_OFController>().father == null)
        {
            //Debug.Log(collision.gameObject.GetComponentInParent<Transform>().name);
            collision.gameObject.GetComponent<TC_OFController>().father = this.gameObject.name;
            collision.gameObject.transform.SetParent(this.gameObject.transform);
            collision.gameObject.GetComponent<TC_OFController>().origPos = new Vector3(0, 0, 0);
            collision.gameObject.GetComponent<TC_OFController>().hits = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.parent = null;
        collision.gameObject.GetComponent<TC_OFController>().father = null;
        collision.gameObject.GetComponent<TC_OFController>().origPos = collision.gameObject.GetComponent<TC_OFController>().origP;
    }
}
