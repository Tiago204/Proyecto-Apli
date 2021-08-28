using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coliciones : MonoBehaviour
{
    public Coleccionable Coleccionable;
    public Rigidbody rb;
    float segundos = 1;
    float impulso = 10;
    int coleccionable = 0;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ARight")
        {
            rb.AddForce(new Vector3(impulso, 0, 0), ForceMode.Impulse);
        }
        if (collision.gameObject.name == "ALeft")
        {
            rb.AddForce(new Vector3(-impulso, 0, 0), ForceMode.Impulse);
        }
        if (collision.gameObject.name == "AForward")
        {
            rb.AddForce(new Vector3(0, 0, impulso), ForceMode.Impulse);
        }
        if (collision.gameObject.name == "ABack")
        {
            rb.AddForce(new Vector3(0, 0, -impulso), ForceMode.Impulse);
        }
        if (collision.gameObject.name == "AUp")
        {
            rb.AddForce(new Vector3(0, impulso, 0), ForceMode.Impulse);
        }
        if (collision.gameObject.name == "Pared")
        {
            Time.timeScale = 0;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Moneda")
        {
            Debug.LogWarning(segundos);
            other.transform.Translate(new Vector3(0, 0, 20) * Time.deltaTime);
            segundos -= Time.deltaTime;
            if (segundos < 0)
            {
                
                Destroy(other.gameObject);
                coleccionable++;
                segundos = 1;
            }
        }
    }
}
