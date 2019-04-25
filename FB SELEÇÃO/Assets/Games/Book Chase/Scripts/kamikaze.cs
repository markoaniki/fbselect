using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamikaze : MonoBehaviour
{
    public float timeToDie = 0.1f;

    // Update is called once per frame
    void Update()
    {
        timeToDie -= Time.deltaTime;
        if(timeToDie < 0) { Destroy(this.gameObject); }
    }
}
