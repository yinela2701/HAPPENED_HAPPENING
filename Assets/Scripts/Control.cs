using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public GameObject panelInicial;
    public GameObject panelBienvenida;
    public GameObject panelTiempo;

    public GameObject panelAcertijo1; 
    public GameObject panelAcertijo2; 
    public GameObject panelAcertijo3;

    public GameObject panelHistoria1; 
    public GameObject panelHistoria2; 
    public GameObject panelHistoria3;

    public GameObject Item1; 
    public GameObject Item2; 
    public GameObject Item3;  

    public GameObject Libro1; 
    public GameObject Libro2; 
    public GameObject Libro3;  

    public InputField Respuesta1; 
    public InputField Respuesta2; 
    public InputField Respuesta3; 

    public InputField inputField; 
    private string nombreJugador;
    public Text mostrarNombre;

    public int puntos; 

    public AudioSource Lograr;


    void Start()
    {
        puntos=0;
        Lograr = GetComponent<AudioSource>();
        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }

    public void DesactivarElPanelInicial()
    {
        nombreJugador = inputField.text;

        Debug.Log("Texto guardado: " + nombreJugador);

        mostrarNombre.text = nombreJugador;

       
        panelInicial.SetActive(false);
        panelBienvenida.SetActive(true);
        
    }
    public void DesactivarElBienvenida()
    {
         panelBienvenida.SetActive(false);
         panelTiempo.SetActive(true);
         Time.timeScale = 1f;
         Cursor.lockState = CursorLockMode.Locked;
    }


     public void DesactivarAcertijo1()
    {
        panelAcertijo1.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void DesactivarAcertijo2()
    {
        panelAcertijo2.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
     public void DesactivarAcertijo3()
    {
        panelAcertijo3.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ActivarItem1()
    {
        if(Respuesta1.text.ToUpper()=="TIEMPO")
        {
            Item1.SetActive(true);
            DesactivarAcertijo1();
            Destroy(Libro1);
            Time.timeScale = 1f;
            Lograr.Play();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ActivarItem2()
    {
        if(Respuesta2.text.ToUpper()=="CREACIÓN")
        {
            Item2.SetActive(true);
            DesactivarAcertijo2();
            Destroy(Libro2);
            Time.timeScale = 1f;
            Lograr.Play();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

     public void ActivarItem3()
    
    {
        if(Respuesta3.text.ToUpper()=="ETERNITY")
        {
            Item3.SetActive(true);
            DesactivarAcertijo3();
            Destroy(Libro3);
            Time.timeScale = 1f;
            Lograr.Play();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }



    public void DesactivarHistoria1()
    {
        panelHistoria1.SetActive(false); 
        puntos++;
        Debug.Log(puntos.ToString());
        Destroy(Item1);
        Time.timeScale = 1f;
        Lograr.Play();
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void DesactivarHistoria2()
    {
        panelHistoria2.SetActive(false); 
        puntos++;
        Debug.Log(puntos.ToString());
        Destroy(Item2);
        Time.timeScale = 1f;
        Lograr.Play();
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void DesactivarHistoria3()
    {
        panelHistoria3.SetActive(false); 
        puntos++;
        Debug.Log(puntos.ToString());
        Destroy(Item3);
        Time.timeScale = 1f;
        Lograr.Play();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void FinalJuego()
    {
        SceneManager.LoadScene("Inicio", LoadSceneMode.Single);
        Lograr.Play();
    }

}
