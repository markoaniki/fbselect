using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_Player : MonoBehaviour
{
    // Singleton
    public static BC_Player plyr = null;

    [Header("Animation Related Variables")]
    public Animator anim;
    public bool wallColider = false;

    [Header("Position Related Variables")]
    private Vector3 dir = new Vector3(0, 0, 0);
    private Vector3 pos;

    [Header("Position Related Variables")]
    public GameObject minXZ;
    public GameObject maxXZ;
    public Vector3 minPosXZ;
    public Vector3 maxPosXZ;

    [Header("Audio Related Variables")]
    public AudioClip audClip;
    public AudioSource audSauce;

    [Header("Other Variables")]
    public float speed = 3f;

    // Awake, Start & Update
    void Awake()
    {
        if (plyr == null) plyr = this;
    }
    void Start()
    {
        audSauce.clip = audClip;
        anim = GetComponentInChildren<Animator>();
        minPosXZ = minXZ.transform.position;
        maxPosXZ = maxXZ.transform.position;
    }
    void Update()
    {
        // Movement
        if(BC_StateMachine.sm.gameState == BC_StateMachine.StateMachine.WAITING_ANSWER)
        {
            pos = transform.position;

            // Running animation controller
            switch (anim.GetInteger("mDir"))
            {
                case 4:
                    transform.rotation = new Quaternion(0, 180f, 0, 0);
                    break;
                case 3:
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    break;
                default:
                    anim.SetInteger("mDir", 0);
                    break;
            }

            if(dir == new Vector3(0,0,0)) anim.SetInteger("mDir", 0);

            dir = Move(dir, anim);

            pos = Vector3.Normalize(dir) * speed * Time.deltaTime;
            pos = CorrectPosition(transform.position + pos);
            transform.position = pos;

            // Sound controller
            if (dir == new Vector3(0, 0, 0) || wallColider)
            {
                if (audSauce.isPlaying) audSauce.Stop();
            }
            else
            {
                if (audSauce.isPlaying == false) audSauce.Play();
            }
        }
    }

    // Movement
    private Vector3 CorrectPosition(Vector3 newPos)
    {
        wallColider = false;
        if (newPos.x < minPosXZ.x)
        {
            wallColider = true;
            anim.SetInteger("mDir", 0);
            newPos.x = minPosXZ.x;
        }
        else if (newPos.x > maxPosXZ.x)
        {
            wallColider = true;
            anim.SetInteger("mDir", 0);
            newPos.x = maxPosXZ.x;
        }

        if (newPos.y < minPosXZ.y)
        {
            wallColider = true;
            anim.SetInteger("mDir", 0);
            newPos.y = minPosXZ.y;
        }
        else if (newPos.y > maxPosXZ.y)
        {
            wallColider = true;
            anim.SetInteger("mDir", 0);
            newPos.y = maxPosXZ.y;
        }

        return newPos;
    }
    public Vector3 Move(Vector3 dir, Animator animation)
    {
        // Up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animation.SetBool("UpDown", false);
            animation.SetInteger("mDir", 1);
            return new Vector3(0, 1, 0);
        }
        // Down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animation.SetBool("UpDown", true);
            animation.SetInteger("mDir", 2);
            return new Vector3(0, -1, 0);
        }
        // Left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animation.SetInteger("mDir", 3);
            return new Vector3(-1, 0, 0);
        }
        //Right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animation.SetInteger("mDir", 4);
            return new Vector3(1, 0, 0);
        }
        // No new input
        return new Vector3(0, 0, 0);
    }

    // Colision
    private void OnCollisionEnter(Collision collision)
    {
        anim.SetInteger("mDir", 0);
        dir = new Vector3(0, 0, 0);

        if(collision.gameObject.GetComponent<BC_Option>().isCorrect) BC_Configuration.config.corQuest++; 

        // WAITING_ANSWER -> SAVING_ANSWER
        BC_StateMachine.sm.gameState = BC_StateMachine.StateMachine.SAVING_ANSWER;
    }
}
