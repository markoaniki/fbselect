using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_TitlePress : MonoBehaviour
{
    public bool updown = false;
    private Vector3 scale;
    public float scaleControl = 1f;
    public float speedControl = 1f;
    private float time = 0;
    public string toCall;
    public AudioClip audClip;
    public AudioSource audSauce;

    // Start is called before the first frame update
    void Start()
    {
        audSauce.clip = audClip;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        transform.localScale = scale * (1 + scaleControl * Mathf.Sin(time * speedControl));

        if (Input.inputString != "")
        {
            if ((int)(Input.inputString[0]) == 13)
            {
                StartCoroutine(Next());
            }
        }
    }

    IEnumerator Next()
    {
        audSauce.Play();
        yield return new WaitWhile(() => audSauce.isPlaying);
        SceneManager.LoadScene(toCall, LoadSceneMode.Single);
    }
}
