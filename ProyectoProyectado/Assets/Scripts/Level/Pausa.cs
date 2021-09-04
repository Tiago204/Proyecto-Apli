using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject pausa;
    public ManageNiveles manageNiveles;
    bool EstaPausa = false;
    [Range(0, 1)] public float CamaraLenta;
    void Update()
    {
        if (manageNiveles.Win == false && manageNiveles.GameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                EstaPausa = !EstaPausa;
            if (EstaPausa)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pausa.SetActive(true);
                Time.timeScale = CamaraLenta;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                pausa.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    public void SeguirTiempo()
    { 
        EstaPausa = false;
    }
}
