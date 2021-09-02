using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelesMenu : MonoBehaviour
{
    public GameObject PNiveles;
    public GameObject PSeguro;
    public GameObject POpciones;
    private void Start()
    {
        PNiveles.SetActive(false);
        PSeguro.SetActive(false);
        POpciones.SetActive(false);
    }
}
