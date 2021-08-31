using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boton : MonoBehaviour
{
    public bool able;
    private void Start()
    {
        GetComponent<Button>().interactable = able;
    }
}
