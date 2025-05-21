using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMusica : MonoBehaviour
{
    public static ControladorMusica Instance;
    public AudioSource musicSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
