using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagOpciones : MonoBehaviour
{
    public int TipoTeclado;

    public Slider slider;
    float slidervalue;
    public Image PBrillo;
    public Light luz;

    static public bool salto;
    static public bool noSalto;

    private void Start()
    {
        TipoTeclado = PlayerPrefs.GetInt("Tipo", 0);

        slidervalue = PlayerPrefs.GetFloat("Brillo", 0);
        slider.value = slidervalue;
        if (slider.value < 0)
        {
            PBrillo.color = new Color(0, 0, 0, -slider.value);
        }
        else
        {
            luz.intensity = slider.value;
        }
    }
    public void Teclado(int Tipo)
    {
        TipoTeclado = Tipo;
        PlayerPrefs.SetInt("Tipo", TipoTeclado);
    }
    public void ChangeSlider(float valor)
    {
        PlayerPrefs.SetFloat("Brillo", valor);
        if (slider.value < 0)
        {
            PBrillo.color = new Color(0, 0, 0, -slider.value);
        }
        else
        {
            luz.intensity = slider.value;
        }
    }
    public void ResetearBrillo()
    {
        slider.value = 0;
    }
    public void Boleanos(int accion)
    {
        switch (accion)
        {
            case 1:
                salto = !salto;
                if (salto)
                    noSalto = false;
                break;
            case 2:
                noSalto = !noSalto;
                if (noSalto)
                    salto = false;
                break;
        }
    }
}
