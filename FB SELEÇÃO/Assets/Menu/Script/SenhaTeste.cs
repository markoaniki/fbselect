using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenhaTeste : MonoBehaviour
{
    public string passwordToEdit = "professorffb";

    void OnGUI()
    {
        passwordToEdit = GUI.PasswordField(new Rect(10, 10, 200, 20), passwordToEdit, "*"[0], 25);
    }
}