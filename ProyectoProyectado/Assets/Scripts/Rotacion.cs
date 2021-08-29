using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public float rotacion;
    private void Update()
    {
        transform.Rotate(new Vector3(0, rotacion, 0) * Time.deltaTime);
    }
}
