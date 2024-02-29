using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public float sensiMouse = 100f;

    public Transform cuerpoJugador;

    //Para rotar la camara
    float rotaX = 0f;
    
    void Start()
    {
        //Bloqueamos la posicion del mouse y lo desaparecemos de la pantalla
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Capturamos los valores de movimiento del Mouse
        float mouseX = Input.GetAxis("Mouse X") * sensiMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensiMouse * Time.deltaTime;

        //Rotamos nuestra camara en el eje X, se usa el - para evitar lo
        //conocido como "Iverted Axis"
        rotaX -= mouseY;

        //Restriccion de rotacion de la camara entre 90 y -90 grados
        rotaX = Mathf.Clamp(rotaX, -90f, 90f);

        //Asignamos los valores resultantes de Rotacion de la camara al objeto como tal
        transform.localRotation = Quaternion.Euler(rotaX, 0f, 0f);

        cuerpoJugador.Rotate(Vector3.up * mouseX);
    }
}
