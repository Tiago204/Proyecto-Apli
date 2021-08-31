using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{
    public bool GameOver = false;
    public bool Win = false;
    public GameObject Gpanel;
    public GameObject Gpanel2;
    public Image panel;
    public Image panel2;
    public Text texto;
    public Text texto2;

    public Image negro;
    public Image restart;
    public Image negro2;
    public Image exit;
    
    public Image negro3;
    public Image restart2;
    public Image negro4;
    public Image exit2;
    public Image negro5;
    public Image siguiente;

    float i, i2;
    private void Awake()
    {
        
    }
    void Start()
    {
        Gpanel.SetActive(false);
        Gpanel2.SetActive(false);

        i = 0;
        i2 = 0;
    }
    void Update()
    {
        if (GameOver)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Gpanel.SetActive(true);
            if (i < 0.5f)
            {
                i += Time.deltaTime/2;
            }
            else if (i2 < 2.55f)
            {
                i2 += Time.deltaTime / 2;
            }
            panel.color = new Color(0, 0, 0, i);
            texto.color = new Color(200, 0, 0, i2);
            negro.color = new Color(0, 0, 0, i2);
            restart.color = new Color(255, 255, 0, i2);
            negro2.color = new Color(0, 0, 0, i2);
            exit.color = new Color(255, 255, 0, i2);
        }
        if (Win)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Gpanel2.SetActive(true);
            if (i < 0.5f)
            {
                i += Time.deltaTime / 2;
            }
            else if (i2 < 2.55f)
            {
                i2 += Time.deltaTime / 2;
            }
            panel2.color = new Color(255, 255, 255, i);
            texto2.color = new Color(255, 155, 0, i2);
            negro3.color = new Color(0, 0, 0, i2);
            restart2.color = new Color(255, 255, 0, i2);
            negro4.color = new Color(0, 0, 0, i2);
            exit2.color = new Color(255, 255, 0, i2);
            negro5.color = new Color(0, 0, 0, i2);
            siguiente.color = new Color(0, 255, 0, i2);
        }
    }
    public void CNiveles(string pNombreScene)
    {
        GameOver = false;
        Gpanel.SetActive(false);
        SceneManager.LoadScene(pNombreScene);
    }
    public void CInterfaz(GameObject pInterfaz)
    {
        pInterfaz.SetActive(true);
    }
    public void NoInterfaz(GameObject pInterfaz)
    {
        pInterfaz.SetActive(false);
    }
}
