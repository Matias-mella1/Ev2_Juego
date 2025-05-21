using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Localizar : MonoBehaviour
{
    public Transform objetivo;
    private UnityEngine.AI.NavMeshAgent agente;
    private float velocidadOriginal;
    private bool velocidadReducida = false;
    private int toques = 0;

    void Start()
    {
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        velocidadOriginal = agente.speed;

        if (objetivo == null)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            if (jugador != null)
                objetivo = jugador.transform;
        }
    }

    void Update()
    {
        if (objetivo != null)
            agente.destination = objetivo.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            toques++;

            if (toques == 1 && !velocidadReducida)
            {
                StartCoroutine(ReducirVelocidad());
            }
            else if (toques == 2)
            {
                PlayerPrefs.SetString("MotivoGameOver", "Kamikaze");
                PlayerPrefs.Save();
                SceneManager.LoadScene("GameOver");
                Destroy(gameObject);
            }
        }
    }

    IEnumerator ReducirVelocidad()
    {
        velocidadReducida = true;
        agente.speed = velocidadOriginal * 0.5f;
        yield return new WaitForSeconds(3f);
        agente.speed = velocidadOriginal;
        velocidadReducida = false;
    }
}

