using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptManager : MonoBehaviour
{
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
    public void Salir()
    {
        Application.Quit();
    }
}
