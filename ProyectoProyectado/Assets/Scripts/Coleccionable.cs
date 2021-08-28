using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public Vector3 rotacion;
    public Vector3 posicion;
    public int subebaja = 1;
    void Start()
    {
        Invoke("Timer", 1f);
    }
    void Update()
    {
        transform.Rotate(rotacion * Time.deltaTime);
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
            transform.Translate(posicion * Time.deltaTime);
        }
        else
        {
            transform.Translate(-posicion * Time.deltaTime);
        }
    }
}
