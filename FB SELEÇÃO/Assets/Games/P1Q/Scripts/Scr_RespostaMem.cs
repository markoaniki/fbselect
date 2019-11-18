using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Scr_RespostaMem : MonoBehaviour
{
    [Header("True = Correto | False = Errado")]
    public bool corf;
    [Header("Selected")]
    public bool selected;

    private Color bnColor;

    // Awake, Start, Update
    void Awake()
    {
        // Para acessar uma informação dentro de um componente de um objeto, se utiliza "GetComponent<Nome do Componente>().Oque quer acessar"
        GetComponent<Button>().onClick.AddListener(delegate () { OnClick(); }); /*Para evitar trabalho manual, isso adiciona no OnClick do Button (Script) a função OnClick*/
        bnColor = GetComponent<Image>().color; /*Guarda a informação da cor original do Image (Script)*/
    }
    void Start()
    {
        Scr_Answer.ans.booty.Add(this.gameObject);
    }
    void Update()
    {
        if (selected) /*Se Selected for Verdadeiro*/
        {
            GetComponent<Button>().transition = Selectable.Transition.None; /*Muda o tipo de Transição do Button (Script) para nenhum*/
            GetComponent<Image>().color = GetComponent<Button>().colors.highlightedColor; /*Muda a cor do Image (script) para a mesma cor do Highlight (Vermelho)*/
        }
        else /*Se Selected for Falso*/
        {
            GetComponent<Button>().transition = Selectable.Transition.ColorTint; /*Retorna o tipo da Transição do Button (Script) para o original (ColorTint)*/
            GetComponent<Image>().color = bnColor; /*Muda a cor do Image (Script) de volta a sua cor original*/
            EventSystem.current.SetSelectedGameObject(null); /*Deseleciona o botão para ele ficar transparente como deve*/
        }
    }

    public void OnClick()
    {
        selected = !selected;
    }
}
