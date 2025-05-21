using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void irOpciones()
    {
        SceneManager.LoadScene("Opciones");
    }
    public void irJugar()
    {
        SceneManager.LoadScene("Juego");
    }

}
