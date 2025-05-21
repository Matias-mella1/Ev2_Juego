using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersoanje : MonoBehaviour
{
    public float velocidad = 5f;
    public float sensibilidadMouse = 2f;
    public Transform camaraJugador;

    private CharacterController controlador;
    private float rotacionVertical = 0f;

    void Start()
    {
        controlador = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Mover();
        Mirar();
    }

    void Mover()
    {
        float ejeX = Input.GetAxis("Horizontal");
        float ejeZ = Input.GetAxis("Vertical");

        Vector3 direccion = transform.right * ejeX + transform.forward * ejeZ;
        controlador.SimpleMove(direccion * velocidad);
    }

    void Mirar()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        rotacionVertical -= mouseY;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -90f, 90f);

        
        camaraJugador.localRotation = Quaternion.Euler(rotacionVertical, 0f, 0f);

        
        transform.Rotate(Vector3.up * mouseX);
    }
}
