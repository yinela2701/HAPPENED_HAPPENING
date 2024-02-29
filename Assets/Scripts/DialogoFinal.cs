using System.Collections;
using UnityEngine;
using TMPro;

public class DialogoFinal : MonoBehaviour
{
   private bool isPlayerInRange;
   private bool empezoDialogo;
   private int lineaIndex;
   public Control control; 

   [SerializeField] private GameObject panelAcertijo;
   [SerializeField] private TMP_Text textoAcertijo; 
   [SerializeField, TextArea(4 , 6)] private string[] lineasAcertijo; 

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange && control.puntos==3)
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
        foreach(char ch in lineasAcertijo[lineaIndex])
        {
            textoAcertijo.text += ch; 
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        
    }
}
