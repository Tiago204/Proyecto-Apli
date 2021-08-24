using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Pre-Game Conf")]
    public Rigidbody rb;
    public Camera maincam;
    [Header("Configuración")]
    public float fuerza;
    public float MaxAcceleration;
    //public float MaxVelocity;
    //Variables
    //float velocidad;
    bool puedosaltar;
    float h, v;
    Vector3 movinput;
    Vector3 movvector;
    Vector3 camforward;
    Vector3 camright;
    void Start()
    {
        
    }
    private void Update()
    {
    }
    void FixedUpdate()
    {
        Debug.Log(rb.velocity.magnitude);
        Moviendo();
        camDirection();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Piso")
        {
            puedosaltar = true;
        }
    }
    void Moviendo()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        movinput = new Vector3(h, 0, v);
        movinput.Normalize();

        movvector = movinput.x * camright + movinput.z * camforward;

        //movvector = Vector3.ClampMagnitude(movvector, MaxAcceleration);
        rb.AddForce(movvector * fuerza * Time.deltaTime, ForceMode.Force);
        //rb.velocity += movvector * fuerza * Time.deltaTime;
        //rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxAcceleration); 
        if (Input.GetKey("space") && puedosaltar == true)
        {
            puedosaltar = false;
            rb.AddForce(new Vector3(0, 4, 0), ForceMode.Impulse);
        }
    }
    void camDirection()
    {
        camforward = maincam.transform.forward;
        camright = maincam.transform.right;

        camforward.y = 0;
        camright.y = 0;

        camforward = camforward.normalized;
        camright = camright.normalized;
    }
}
