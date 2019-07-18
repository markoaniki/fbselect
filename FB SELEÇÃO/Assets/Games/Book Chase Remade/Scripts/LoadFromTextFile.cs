using UnityEngine;

public class LoadFromTextFile : MonoBehaviour {

    void Start()
    {
        TextAsset arquivosTXT = Resources.Load<TextAsset>("QuestionsR");
        Debug.Log(arquivosTXT.text);
    }
}