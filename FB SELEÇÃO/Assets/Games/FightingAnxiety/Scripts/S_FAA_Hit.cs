using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class S_FAA_Hit : MonoBehaviour
{

    // Awake, Start, Update
    void Start()
    {

    }
    void Update()
    {
        transform.position += new Vector3(0, .005f, 0);
        GetComponent<TextMeshProUGUI>().color = new Color(GetComponent<TextMeshProUGUI>().color.r, GetComponent<TextMeshProUGUI>().color.g, GetComponent<TextMeshProUGUI>().color.b, GetComponent<TextMeshProUGUI>().color.a - .025f);
        if(GetComponent<TextMeshProUGUI>().color.a <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
