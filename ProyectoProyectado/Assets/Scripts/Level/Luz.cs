using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
    public Transform jugador;
    private void Update()
    {
        this.transform.position = jugador.position + new Vector3(0, 40, 0);
    }
}
