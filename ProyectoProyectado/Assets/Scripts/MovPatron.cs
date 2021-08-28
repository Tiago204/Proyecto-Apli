using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SMovimiento
{
    public float rotacion;
    public float tiempo;
    public float velocidad;
    public float velrotacion;

    public SMovimiento(float pRotacion, float pTiempo, float pVelocidad, float pVelRotacion)
    {
        rotacion = pVelRotacion;
        tiempo = pTiempo;
        velocidad = pVelocidad;
        velrotacion = pVelRotacion;
    }
}
public class MovPatron : MonoBehaviour
{
    
}
