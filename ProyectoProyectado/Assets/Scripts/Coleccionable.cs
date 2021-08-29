using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public float rotacion;
    public float posicion;
    int subebaja = 1;
    void Start()
    {
        Invoke("Timer", 1f);
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotacion) * Time.deltaTime);
        Tranladar();
    }
    void Timer()
    {
        subebaja = subebaja * -1;
        Invoke("Timer", 1f);
    }
    void Tranladar()
    {
        if (subebaja == 1)
        {
            transform.Translate(new Vector3(0, 0, posicion) * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(0, 0, -posicion) * Time.deltaTime);
        }
    }
}
