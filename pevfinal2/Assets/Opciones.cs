using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Opciones : MonoBehaviour
{
    public TMP_InputField InputNombre;
    public TMP_Dropdown DropdownDificultad;
    public Slider SliderVolumen;

    void Start()
    {
        if (InputNombre != null)
        {
            
            string nombreGuardado = PlayerPrefs.GetString("NombreJugador", "");

            /
            if (string.IsNullOrEmpty(nombreGuardado))
            {
                nombreGuardado = "Jugador"; 
            }

            
            InputNombre.text = nombreGuardado;
        }


        if (DropdownDificultad != null)
            DropdownDificultad.value = PlayerPrefs.GetInt("Dificultad", 0);

        if (SliderVolumen != null)
        {
            SliderVolumen.value = PlayerPrefs.GetFloat("Volumen", 1f);
            CambiarVolumen(SliderVolumen.value);
        }

    }

    public void Guardar()
    {
        if (InputNombre == null || DropdownDificultad == null || SliderVolumen == null)
        {
            Debug.LogError("Uno o más componentes no están asignados en el Inspector.");
            return;
        }

        PlayerPrefs.SetString("NombreJugador", InputNombre.text);
        PlayerPrefs.SetInt("Dificultad", DropdownDificultad.value);
        PlayerPrefs.SetFloat("Volumen", SliderVolumen.value);
        PlayerPrefs.Save();

        CambiarVolumen(SliderVolumen.value);
    }


    public void CambiarVolumen(float valor)
    {
        if (ControladorMusica.Instance != null && ControladorMusica.Instance.musicSource != null)
        {
            ControladorMusica.Instance.musicSource.volume = valor;
        }
    }

    public void volver()
    {

        SceneManager.LoadScene("Menu");
    }

    
}
