using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagOpciones : MonoBehaviour
{
    public Button Teclado1;
    public Button Teclado2;
    static public int TipoTeclado;
    private void Start()
    {
        TipoTeclado = PlayerPrefs.GetInt("Tipo");
    }
    private void Update()
    {
        if (TipoTeclado == 0)
        {
            Teclado1.interactable = false;
            Teclado2.interactable = true;
        }
        else
        {
            Teclado1.interactable = true;
            Teclado2.interactable = false;
        }
    }
    public void Teclado(int Teclado)
    {
        TipoTeclado = Teclado;
        PlayerPrefs.SetInt("Tipo", TipoTeclado);
    }
    public void SiInteract(Button Boton)
    {  Boton.interactable = true;}
    public void NoInteract(Button Boton)
    { Boton.interactable = false; }
}
