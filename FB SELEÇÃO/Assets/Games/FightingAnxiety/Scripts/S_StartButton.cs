using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_StartButton : MonoBehaviour
{
    [Header("Button Animation")]
    public SpriteRenderer anim;
    public Image img;

    [Header("Audio: ")]
    public AudioClip audClip = null;
    public AudioSource audSauce = null;

    [Header("Scene File Path: ")]
    public string nextScenePath;

    // Start & Update
    void Start()
    {
        if(audSauce != null)audSauce.clip = audClip;
    }
    void Update()
    {
        img.sprite = anim.sprite;   
    }

    // Button Interaction
    public void OnClick()
    {
//      StartCoroutine(Next());
        SceneManager.LoadScene(nextScenePath, LoadSceneMode.Single);
    }

    /*IEnumerator Next()
    {
        if (audSauce != null)
        {
            audSauce.Play();
            yield return new WaitWhile(() => audSauce.isPlaying);
        }
    }*/
}
