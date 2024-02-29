using System.Collections;
using UnityEngine;
using TMPro;

public class DialogoAcertijo : MonoBehaviour
{
   private bool isPlayerInRange;
   private bool empezoDialogo;
   private int lineaIndex;
   public AudioSource audioSource;


   //[SerializeField] private AudioClip escritura;
   //[SerializeField] private AudioClip encontrarLibro;

   [SerializeField] private float TiempoEscritura;
   [SerializeField] private int tiempoCaracter;

   [SerializeField] private GameObject panelAcertijo;
   [SerializeField] private TMP_Text textoAcertijo; 
   [SerializeField, TextArea(4 , 6)] private string[] lineasAcertijo; 

   
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange)
        {
            if(!empezoDialogo)
            {
                EmpezarAcertijo();
            }

        }
    }
     

    private void EmpezarAcertijo()
    {
        empezoDialogo= true;
        panelAcertijo.SetActive(true);
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


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
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
