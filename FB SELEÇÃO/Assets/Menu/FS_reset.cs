using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FS_reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (FaseSelector.FS != null)
        {
            FaseSelector.FS.returnToMainGame();
        }
    }

    public void OnButtonClick()
    {
        if (FaseSelector.FS != null)
        {
            FaseSelector.FS.exitMainGame();
        }
    }
}
