using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P3Q_ChangeImage : MonoBehaviour
{
    public Image imgOri = null;
    public Sprite imgNew = null;
    public Sprite imgSel = null;
    public bool isCorrect = false;

    private Sprite imgOr = null;
    private bool isSelected = false;
    private bool canSelect = true;

    private void Start()
    {
        imgOr = imgOri.sprite;
    }

    public void SpriteChange()
    {
        if (!isSelected)
        {
            canSelect = !canSelect;
            imgOri.sprite = imgNew;
        }
    }

    public void OnClick()
    {
        if (!canSelect) { return; }
        isSelected = !isSelected;
        if (isSelected) { imgOri.sprite = imgSel; } else { imgOri.sprite = imgOr; }
    }

    //Verifica se a resposta foi marcada corretamente ou não
    public bool DidItHit()
    {
        if (isCorrect == isSelected) { return true; }
        return false;
    }
}
