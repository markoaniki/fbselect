using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UNIVERSAL_GoBackButton : MonoBehaviour
{
    [Header("Path")]
    public string path = null; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            WHTGBack();
        }
    }

    public void WHTGBack()
    {
        if (!string.IsNullOrEmpty(path))
        {
            SceneManager.LoadScene(path, LoadSceneMode.Single);
        } else
        {
            Debug.Log("ERROR: Missing Path");
        }
    }
}
