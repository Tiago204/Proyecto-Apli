using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Pre-Game Conf")]
    public Rigidbody rb;
    public Camera maincam;
    public ScriptManager ScriptManager;
    [Header("Configuración")]
    public float fuerza;
    public float MaxAcceleration;
    bool puedosaltar;
    float h, v;
    Vector3 movinput;
    Vector3 movvector;
    Vector3 camforward;
    Vector3 camright;
    private void Awake()
    {

    }
    void Start()
    {
    }
    void FixedUpdate()
    {
        Moviendo();
        camDirection();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Piso" || collision.gameObject.name == "ARight" || collision.gameObject.name == "ALeft" || collision.gameObject.name == "AForward" || collision.gameObject.name == "ABack" || collision.gameObject.name == "AUp")
        {
            puedosaltar = true;
        }
    }
    void Moviendo()
    {
        if (ScriptManager.TipoTeclado)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            movinput = new Vector3(h, 0, v);
            movinput.Normalize();
            movvector = movinput.x * camright + movinput.z * camforward;
            if (rb.velocity.magnitude < MaxAcceleration)
            {
                rb.AddForce(movvector * fuerza, ForceMode.Force);
            }
        }
        else
        {

            if (Input.GetKey("left"))
            {
                movvector = -1 * camright + 0 * camforward;
                rb.AddForce(movvector * fuerza, ForceMode.Force);

            }
            if (Input.GetKey("right"))
            {
                movvector = 1 * camright + 0 * camforward;
                rb.AddForce(movvector * fuerza, ForceMode.Force);
            }
            if (Input.GetKey("down"))
            {
                movvector = 0 * camright + -1 * camforward;
                rb.AddForce(movvector * fuerza, ForceMode.Force);
            }
            if (Input.GetKey("up"))
            {
                movvector = 0 * camright + 1 * camforward;
                rb.AddForce(movvector * fuerza, ForceMode.Force);
            }
        }
        

        

        if (Input.GetKey("space") && puedosaltar == true)
        {
            puedosaltar = false;
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
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
