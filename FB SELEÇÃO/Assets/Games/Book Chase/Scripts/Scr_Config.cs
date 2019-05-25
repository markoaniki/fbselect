using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Config : MonoBehaviour
{
    // Singleton
    public static Scr_Config conf = null;

    // Variables
    public float speed = 5.5f;
    public bool isFree = true;
    public bool isInte = true;
    public bool isProcedural = true;
    public bool difficulty = true;
    public float scrsPQ = 0.03f; // Scores per question;

    // Awake, Start & Update
    void Start()
    {
        if(conf == null)
        {
            conf = this;
        }
    }
    void Update()
    {
        
    }

    // Math
        // Check if the numbers need to be integer
        public float IsInteger(float valEx)
        {
            LogSave.ls.SaveLog("IsInteger Executado | ");
            if (isInte)
            {
                return Mathf.Floor(valEx);
            }

            return valEx;
        }
        // Use a Random Range applying Mathf.Floor if needed
        public float RandomNum(float min, float max)
        {
            //Log
            LogSave.ls.SaveLog("RandomNum Executado | ");
            return conf.IsInteger(Random.Range(min, max));
        }
        // Convert Degrees to Radius
        public float DegreesToRadius(float angle)
        {
            LogSave.ls.SaveLog("DegreesToRadius Executado | ");
            return angle * Mathf.PI / 180;
        }

    // Text
    public string TextFormat()
    {
        if (isInte)
        {
            return "F0";
        }

        return "F2";
    }

    // Movement
    public Vector3 Move(Vector3 dir, Animator animation)
    {
        // Up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animation.SetBool("UpDown", false);
            animation.SetInteger("mDir", 1);
            return new Vector3(0, 0, 1);
        }
        // Down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animation.SetBool("UpDown", true);
            animation.SetInteger("mDir", 2);
            return new Vector3(0, 0, -1);
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
}
