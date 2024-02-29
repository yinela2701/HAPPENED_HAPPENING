using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioJuego : MonoBehaviour
{
    public void IniciarJuego()
    {
          SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
   void Update()
    {
        // Si se presiona la tecla "Escape", cierra el juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
