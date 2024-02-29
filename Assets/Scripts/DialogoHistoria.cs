using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoHistoria : MonoBehaviour
{
    public AudioSource audioSource;
   private bool isPlayerInRange;
   private bool empezoDialogo;
   private int lineaIndex;

   [SerializeField] private GameObject panelAcertijo1;
   [SerializeField] private TMP_Text textoAcertijo; 
   [SerializeField, TextArea(4 , 20)] private string[] lineasAcertijo; 

   [SerializeField] private float TiempoEscritura;
   [SerializeField] private int tiempoCaracter;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
            if(!empezoDialogo)
            {
                EmpezarAcertijo();
            }
            else if(textoAcertijo.text == lineasAcertijo[lineaIndex] )
            {
                SiguienteLineaAcertijo();

            }
            else
            {
                StopAllCoroutines();
                textoAcertijo.text = lineasAcertijo[lineaIndex];
            }
        }
    }
     

    private void EmpezarAcertijo()
    {
        empezoDialogo= true;
        panelAcertijo1.SetActive(true);
        lineaIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(MostrarLineas());

    }

    private IEnumerator MostrarLineas()
    {
        textoAcertijo.text = string.Empty;
        int caracterActual = 0;
        
        foreach(char ch in lineasAcertijo[lineaIndex])
        {
            textoAcertijo.text += ch; 

            if(caracterActual % tiempoCaracter == 0)
            {
                audioSource.Play();
            }

            caracterActual++;
            yield return new WaitForSecondsRealtime(TiempoEscritura);
        }
    }

    private void SiguienteLineaAcertijo()
    {
        lineaIndex ++;
        if(lineaIndex < lineasAcertijo.Length)
        {
            StartCoroutine(MostrarLineas());
        }
        else
        {
            empezoDialogo = false;
            Time.timeScale = 1f;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
        }
        
    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            
        }
        
    }
   
}

