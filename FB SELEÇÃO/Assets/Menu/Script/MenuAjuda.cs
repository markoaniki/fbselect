using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAjuda : MonoBehaviour
{
    public GameObject Ajuda;

    // Start is called before the first frame update
    public void Start()
    {
        Ajuda.SetActive(false);
    }

    public void OnMouseOver()
    {
        Ajuda.SetActive(true);
        Debug.Log("Mouse ativo");
    }
    
    // Update is called once per frame
    public void OnMouseExit()
    {
        Ajuda.SetActive(false);
        Debug.Log("Mouse não ativo");
    }
}
