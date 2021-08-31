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
    private int cantPasos;
    private List<SMovimiento> patron = new List<SMovimiento>();
    private float tiempo = 0;
    private int indice = 0;
    private Vector3 direccion;
    [Header("Configuración")]
    public float latencia;
    void Start()
    {
        //rotacion - tiempo - velocidad - velocidad de rotacion
        patron.Add(new SMovimiento(0, 1, -4, 0));
        patron.Add(new SMovimiento(0, 1, 4, 0));

        cantPasos = patron.Count;
        indice = 0;
    }
    void Update()
    {
        Invoke("Pattern", latencia);
    }
    void Pattern()
    {
        tiempo += Time.deltaTime;
        if (tiempo > patron[indice].tiempo)
        {
            tiempo = 0;
            indice++;
            if (indice >= cantPasos)
                indice = 0;
        }
        direccion = Quaternion.AngleAxis(patron[indice].rotacion, Vector3.up) * transform.forward;

        Quaternion rotObjetivo = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotObjetivo, patron[indice].velrotacion * Time.deltaTime);

        transform.Translate(transform.forward * patron[indice].velocidad * Time.deltaTime);
    }
}

