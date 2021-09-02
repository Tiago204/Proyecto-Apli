using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{
    public Button Teclado1;
    public Button Teclado2;
    static public bool TipoTeclado = true;
    private void Update()
    {
        if (TipoTeclado)
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
    public void CNiveles(string pNombreScene)
    {
        SceneManager.LoadScene(pNombreScene);
    }
    public void CInterfaz(GameObject pInterfaz)
    {
        pInterfaz.SetActive(true);
    }
    public void NoInterfaz(GameObject pInterfaz)
    {
        pInterfaz.SetActive(false);
    }
    public void Teclado(bool Teclado)
    {
        TipoTeclado = Teclado;
        


    }
    public void Salir()
    {
        Application.Quit();
    }
}
