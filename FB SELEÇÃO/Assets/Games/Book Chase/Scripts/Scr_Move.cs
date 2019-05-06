using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Move : MonoBehaviour
{
    // Variables
    private Vector3 dir = new Vector3(0, 0, 0);
    private Vector3 pos;
    public Animator animation;
    public float cool = 1f;
    public GameObject minXZ;
    public GameObject maxXZ;
    private Vector3 minPosXZ;
    private Vector3 maxPosXZ;
    public AudioClip audClip;
    public AudioSource audSauce;
    private bool onWall = false;
    // Start & Update
    void Start()
    {
        audSauce.clip = audClip;
        animation = GetComponentInChildren<Animator>();
        minPosXZ = minXZ.transform.position;
        maxPosXZ = maxXZ.transform.position;
    }
    void Update()
    {
        pos = transform.position;

        // Running animation controller
        if (animation.GetInteger("mDir") == 4)
        {
            transform.rotation = new Quaternion(0, 0, 180f, 0);
        }
        else if (animation.GetInteger("mDir") == 3)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if (dir == new Vector3(0, 0, 0))
        {
            animation.SetInteger("mDir", 0);
        }

        dir = Scr_Config.conf.Move(dir, animation);

        pos = Vector3.Normalize(dir) * Scr_Config.conf.speed * Time.deltaTime;
        pos = CorrectPosition(transform.position + pos);
        transform.position = pos;

        // Sound controller
        if (dir == new Vector3(0, 0, 0) || onWall)
        {
            if (audSauce.isPlaying) audSauce.Stop();
        }
        else
        {
            if (audSauce.isPlaying == false) audSauce.Play();
        }
    }

    // Correct Position
    Vector3 CorrectPosition(Vector3 newPos)
    {
        onWall = false;
        if (newPos.x < minPosXZ.x)
        {
            onWall = true;
            animation.SetInteger("mDir", 0);
            newPos.x = minPosXZ.x;
        }
        else if (newPos.x > maxPosXZ.x)
        {
            onWall = true;
            animation.SetInteger("mDir", 0);
            newPos.x = maxPosXZ.x;
        }

        if (newPos.z < minPosXZ.z)
        {
            onWall = true;
            animation.SetInteger("mDir", 0);
            newPos.z = minPosXZ.z;
        }
        else if (newPos.z > maxPosXZ.z)
        {
            onWall = true;
            animation.SetInteger("mDir", 0);
            newPos.z = maxPosXZ.z;
        }

        return newPos;
    }

    // OnCollision
    private void OnCollisionEnter(Collision collision)
    {
        animation.SetInteger("mDir", 0);
        LogSave.ls.SaveLog("OnCollisionEnter of Scr_Move Executado | ");
        dir = new Vector3(0, 0, 0);
        cool = 1f;
    }
}
