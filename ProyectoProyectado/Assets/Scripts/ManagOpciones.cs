using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagOpciones : MonoBehaviour
{
    public int TipoTeclado;
    private void Start()
    {
        TipoTeclado = PlayerPrefs.GetInt("Tipo", 0);
    }
    public void Teclado(int Tipo)
    {
        TipoTeclado = Tipo;
        PlayerPrefs.SetInt("Tipo", TipoTeclado);
    }
}
