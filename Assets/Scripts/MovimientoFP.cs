using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFP : MonoBehaviour
{
    public float veloMovi = 2f;
    public float gravedad = -9.81f;
    //public float salto = 4f;
    public AudioSource audioSource; 

    public CharacterController controlador;
    //public Transform checkPiso;
    //public float distanciaPiso = 0.4f;
    //public LayerMask piso;

    //bool enPiso;

    Vector3 velocidad;
    private void Start() 

    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //enPiso = Physics.CheckSphere(checkPiso.position,distanciaPiso, piso);

        //if (enPiso && velocidad.y < 0)
        //{
        //    velocidad.y = -2f;
        //}
       
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (x != 0 || z != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

        Vector3 movimiento = transform.right * x + transform.forward * z;

        controlador.Move(movimiento * veloMovi * Time.deltaTime);

        //if (Input.GetButtonDown("Jump") && enPiso)
        //{
        //    velocidad.y = Mathf.Sqrt(salto * -2f * gravedad);
        //}

        //Implementacion de gravedad en el objeto
        velocidad.y += gravedad * Time.deltaTime;
        controlador.Move(velocidad * Time.deltaTime);
       
        
    }

}
