using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text mensajeGameOver;

    void Start()
    {
       
        string motivo = PlayerPrefs.GetString("MotivoGameOver", "Desconocido");

        if (motivo == "Tiempo")
        {
            mensajeGameOver.text = "¡Has perdido por término del tiempo!";
        }
        else if (motivo == "Kamikaze")
        {
            mensajeGameOver.text = "¡Has perdido por un kamikaze!";
        }
        else
        {
            mensajeGameOver.text = "¡Game Over!";
        }

        StartCoroutine(VolverMenuAutomaticamente());

    }

    private IEnumerator VolverMenuAutomaticamente()
    {
        yield return new WaitForSeconds(5f);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

}
