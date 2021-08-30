using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacionluz : MonoBehaviour
{
    public float rota;
    public float transl;
    private void Update()
    {
        transform.Rotate(new Vector3(rota, 0, 0) * Time.deltaTime);
        transform.Translate(new Vector3(0, transl, 0) * Time.deltaTime);
    }
}
