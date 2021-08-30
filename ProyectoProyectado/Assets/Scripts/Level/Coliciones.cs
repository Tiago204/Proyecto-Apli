using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coliciones : MonoBehaviour
{
    public Coleccionable Coleccionable;
    public Rigidbody rb;
    public ScriptManager ScriptManager;
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
        if (collision.gameObject.tag == "Pared" || collision.gameObject.tag == "IA" || collision.gameObject.name == "Vacio")
        {
            ScriptManager.GameOver = true;
            rb.isKinematic = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Moneda")
        {
            other.transform.Translate(new Vector3(0, 0, -3) * Time.deltaTime);
            Destroy(other.gameObject, 0.5f);
            
            coleccionable++;
        }
    }
}
