using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senha : MonoBehaviour
{
    public string passwordToEdit = "My Password";

    void OnGUI()
    {
        passwordToEdit = GUI.PasswordField(new Rect(10, 10, 200, 20), passwordToEdit, "*"[0], 25);
    }
}