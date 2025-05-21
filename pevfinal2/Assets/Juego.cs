using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Juego : MonoBehaviour
{
    public TMP_Text textoNombre;
    public TMP_Text textoDificultad;
    public TMP_Text textoTiempo;

    private float tiempoRestante = 30f;  
    private bool tiempoActivo = true;

    void Start()
    {
        string nombre = PlayerPrefs.GetString("NombreJugador", "Jugador");
        textoNombre.text = "Nombre: " + nombre;

        string dificultadTexto = PlayerPrefs.GetString("TextoDificultad", "Fácil");
        textoDificultad.text = "Dificultad: " + dificultadTexto;

        textoTiempo.text = "Tiempo: " + Mathf.Ceil(tiempoRestante) + "s";
        AjustarVelocidadEnemigos();
    }

    void Update()
    {

        if (tiempoActivo)
        {
            tiempoRestante -= Time.deltaTime;
            float tiempoMostrado = Mathf.Clamp(tiempoRestante, 0f, 999f);
            textoTiempo.text = "Tiempo: " + Mathf.Ceil(tiempoMostrado) + "s";

            if (tiempoRestante <= 0)
            {
                tiempoActivo = false;
             
                PlayerPrefs.SetString("MotivoGameOver", "Tiempo");
                PlayerPrefs.Save();

                
                SceneManager.LoadScene("GameOver");
            }
        }
    }

 
    public void PerderPorKamikaze()
    {
        PlayerPrefs.SetString("MotivoGameOver", "Kamikaze");
        PlayerPrefs.Save();

        SceneManager.LoadScene("GameOver");
    }

    void AjustarVelocidadEnemigos()
    {
        
        int dificultad = PlayerPrefs.GetInt("Dificultad", 0);

        float velocidad = 20f; 

        switch (dificultad)
        {
            case 0:
                velocidad = 20f;
                break;
            case 1:
                velocidad = 30f;
                break;
            case 2:
                velocidad = 40f;
                break;
        }

     
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");

        foreach (GameObject enemigo in enemigos)
        {
            UnityEngine.AI.NavMeshAgent agente = enemigo.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (agente != null)
            {
                agente.speed = velocidad;
            }
        }
    }
}
