using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coliciones : MonoBehaviour
{
    public Coleccionable Coleccionable;
    public Rigidbody rb;
    public ManageNiveles manageNiveles;
    public Tiempo Tiempo;
    public Text TColec;
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
            manageNiveles.GameOver = true;
            rb.isKinematic = true;
            Tiempo.Fin = true;
        }
        if (collision.gameObject.name == "Meta")
        {
            manageNiveles.Win = true;
            rb.isKinematic = true;
            Tiempo.Fin = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Moneda")
        {
            other.transform.position = new Vector3(this.transform.position.x, other.transform.position.y, this.transform.position.z);
            other.transform.Translate(new Vector3(0, 0, -3) * Time.deltaTime);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Moneda")
        {
            Destroy(other.gameObject, 1f);
            coleccionable++;
            TColec.text = "Coleccionable: " + coleccionable + "/1";
        }
    }
}
