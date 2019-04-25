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

    // Start & Update
    void Start()
    {
        animation = GetComponentInChildren<Animator>();
        minPosXZ = minXZ.transform.position;
        maxPosXZ = maxXZ.transform.position;
    }
    void Update()
    {
        pos = transform.position;

        // Running animation controller
        if(animation.GetInteger("mDir") == 4)
        {
            transform.rotation = new Quaternion(0, 0, 180f, 0);
        } else if(animation.GetInteger("mDir") == 3)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if (cool <= 0)
        {
            if(dir == new Vector3(0, 0, 0))
            {
                animation.SetInteger("mDir", 2);
                dir = new Vector3(0, 0, -1);
            }

            dir = Scr_Config.conf.LeftRight(dir, animation);
            dir = Scr_Config.conf.UpDown(dir, animation);

            pos = Vector3.Normalize(dir) * Scr_Config.conf.speed * Time.deltaTime;
            pos = CorrectPosition(transform.position + pos);
            transform.position = pos;
        }
        else if(cool > 0f)
        {
            cool -= Time.deltaTime;
        }
    }

    // Correct Position
    Vector3 CorrectPosition(Vector3 newPos)
    {
        if (newPos.x < minPosXZ.x)
        {
            animation.SetInteger("mDir", 0);
            newPos.x = minPosXZ.x;
        }
        else if (newPos.x > maxPosXZ.x)
        {
            animation.SetInteger("mDir", 0);
            newPos.x = maxPosXZ.x;
        }

        if (newPos.z < minPosXZ.z)
        {
            animation.SetInteger("mDir", 0);
            newPos.z = minPosXZ.z;
        }
        else if (newPos.z > maxPosXZ.z)
        {
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
