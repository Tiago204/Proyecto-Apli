using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScrip : MonoBehaviour
{
    [Header("Pre-Game Conf")]
    public Transform empty;
    public Transform t_cam;
    [Header("Configuración")]
    public float Sensibilidad_X = 5.0f;
    public float Sensibilidad_Y = 3.0f;
    [Range(0, 1)] public float latencia;
    public Vector3 cam_offset;
    public bool blockcursor;
    public bool HabilitarZoom;
    //Variables
    float h, v;
    RaycastHit hit;
    GameObject target;
    float hitdistance;
    Vector3 newposition;
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
        Vector3 look = transform.position + new Vector3(0, 1, 0);
        t_cam.LookAt(look);
    }
    private void Update()
    {
        if (HabilitarZoom) { Zoom(); }    
        
    }
    void FixedUpdate()
    {
        CamColisions();
    }
    private void LateUpdate()
    {
        Coaliciones();
        Vector3 look = transform.position + new Vector3(0, 1, 0);
        t_cam.LookAt(look);
        RotacionCam();
    }

    void CamColisions()
    {
        hitdistance = 15;
        if (Physics.Linecast(this.transform.position, this.transform.position + cam_offset, out hit))
        {
            Debug.DrawLine(this.transform.position, this.transform.position + cam_offset, Color.red);
            Debug.DrawRay(hit.point, Vector3.back);
            hitdistance = Mathf.Min(hitdistance, hit.distance);
        }
        else
        {
            Debug.DrawLine(this.transform.position, this.transform.position + cam_offset, Color.green);
        }
        if (hitdistance > 14)
        {
            hitdistance = 0;
        }
    }
    void Coaliciones()
    {
        newposition = hit.point - Vector3.forward * 0.1f + Vector3.up * 0.8f;
        if (hitdistance > 0)
        {
            t_cam.localPosition = newposition;
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
        t_cam.localPosition = Vector3.Lerp(t_cam.localPosition, transform.position + cam_offset, latencia);
            //Vector3 ea = t_cam.rotation.eulerAngles;
            //t_cam.rotation = Quaternion.Euler(new Vector3(ea.x, ea.y, 0));
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
