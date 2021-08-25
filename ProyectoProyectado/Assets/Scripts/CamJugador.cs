using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamJugador : MonoBehaviour
{
    [Header("Pre-Game Conf")]
    public Transform player;
    [Header("Configuración")]
    public float Sensibilidad_X;
    public float Sensibilidad_Y;
    [Range(0, 1)] public float latencia;
    public Vector3 cam_offset;
    public bool blockcursor;
    public bool HabilitarZoom;
    //Variables
    float h, v;
    RaycastHit hit;
    float hitdistance;
    Vector3 newposition;
    //Vector3 lastposition;
    void Start()
    {
        if (blockcursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Vector3 look = player.position + new Vector3(0, 1, 0);
        this.transform.LookAt(look);
        //Invoke("Timer", 1f);
    }
    private void Update()
    {
        if (HabilitarZoom) { Zoom(); }    
    }
    void FixedUpdate()
    { 
    }
    void Timer()
    {
        Invoke("Timer", 1f);
    }
    private void LateUpdate()
    {
        CamColisions();
        Vector3 look = player.position + new Vector3(0, 1, 0);
        this.transform.LookAt(look);
        RotacionCam();
    }
    
    void CamColisions()
    {
        hitdistance = 15;
        if (Physics.Linecast(player.position, player.position + cam_offset, out hit))
        {
            Debug.DrawLine(player.position, player.position + cam_offset, Color.red);
            Debug.DrawRay(hit.point, Vector3.back);
            hitdistance = Mathf.Min(hitdistance, hit.distance);
        }
        else
        {
            Debug.DrawLine(player.position, player.position + cam_offset, Color.green);
        }
        if (hitdistance > 14)
        {
            hitdistance = 0;
        }
    }
    void RotacionCam()
    {
        h = Input.GetAxis("Mouse X");
        v = Input.GetAxis("Mouse Y");
        //Lo saco porque no estoy seguro lo que modifica, puede se que con skins lo averigue.
        //if (h != 0)
        //{
        //    transform.Rotate(Vector3.up, h * 90 * Sensibilidad_X * Time.deltaTime);
        //}
        //if (v != 0)
        //{
        //    t_cam.RotateAround(transform.position, transform.right, v * 90 * Sensibilidad_Y * Time.deltaTime);
        //}
        cam_offset = Quaternion.AngleAxis(h * Sensibilidad_X, Vector3.up) * cam_offset;
        if (hitdistance > 0)
        {
            newposition = hit.point - Vector3.forward * 0.1f + Vector3.up * 0.8f;
        }
        else
        {
            newposition = player.position + cam_offset;
        }
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, newposition, latencia);
        
        Vector3 ea = this.transform.rotation.eulerAngles;
        this.transform.rotation = Quaternion.Euler(new Vector3(ea.x, ea.y, 0));
    }
    void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        scroll = Mathf.Clamp(scroll, -0.1f, 0.1f);
        if (scroll != 0)
        {
            cam_offset.z = cam_offset.z + scroll * 5;
            cam_offset.y = cam_offset.y + scroll * -1;
        }
        
    }
}
