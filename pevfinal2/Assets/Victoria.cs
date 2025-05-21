using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float tiempo = Time.timeSinceLevelLoad;
            PlayerPrefs.SetFloat("TiempoFinal", tiempo);
            PlayerPrefs.SetString("MotivoGameOver", "Victoria");
            SceneManager.LoadScene("Victoria");  
        }
    }

}
