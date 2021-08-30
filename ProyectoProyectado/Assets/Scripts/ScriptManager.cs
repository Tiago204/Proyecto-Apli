using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{
    public bool GameOver = false;
    public GameObject Gpanel;
    public GameObject Menu;
    public Image panel;
    public Text texto;
    public Image negro;
    public Image restart;
    public Image negro2;
    public Image exit;
    float i, i2;
    void Start()
    {
        Gpanel.SetActive(false);
        i = 0;
        i2 = 0;
    }
    void Update()
    {
        if (GameOver)
        {
            Debug.LogWarning(i);
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
