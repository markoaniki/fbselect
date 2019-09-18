using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceResolutionClick : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        Screen.SetResolution(1024, 768, true);
        QualitySettings.SetQualityLevel(5, true);
    }

}
