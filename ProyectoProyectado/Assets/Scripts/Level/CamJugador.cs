using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamJugador : MonoBehaviour
{
    [Header("Pre-Game Conf")]
    public Transform player;
    public ManagOpciones ManagOpciones;
    [Header("Configuración")]
    public float Sensibilidad_X;
    public float Sensibilidad_Y;
    [Range(0, 1)] public float latencia;
    public Vector3 cam_offset;
    public bool blockcursor;
    public bool HabilitarZoom;
    //Variables
    float h, v;
    bool Left, Right;
    RaycastHit hit;
    float hitdistance;
    Vector3 newposition;
    private void Awake()
    {
    }
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
    }
    private void Update()
    {
        if (HabilitarZoom) { Zoom(); }    
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
        if (ManagOpciones.TipoTeclado == 0)
        {
            h = Input.GetAxis("Mouse X");
            v = Input.GetAxis("Mouse Y");
        }
        else
        {
            Left = Input.GetKey("a");
            Right = Input.GetKey("d");
            if (Left)
                h = -1;
            else if (Right)
                h = 1;
            else
                h = 0;
        }
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
