using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    //public static ControladorTiempo InstanceTiempo;


    [SerializeField] int min, seg;
    [SerializeField] Text tiempo;
    //public GameObject Puntos;

    private float restante;
    private bool enMarcha;

    private void Awake()
    {
        //if(ControladorTiempo.InstanceTiempo == null )
        //{
        //  ControladorTiempo.InstanceTiempo = this;
        //  DontDestroyOnLoad(this.gameObject);
        //}
        //else
        //{
        //  Destroy(gameObject);  
        //}
        
        restante = (min*60) + seg;
        enMarcha = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enMarcha)
        {
          restante -= Time.deltaTime;   
          if(restante < 1)
          {
            enMarcha = true;
            SceneManager.LoadScene("Inicio", LoadSceneMode.Single);
            //Destroy(this.gameObject);
            //Destroy(Puntos);
          }

          int tempMin = Mathf.FloorToInt(restante /60);
          int tempSeg = Mathf.FloorToInt(restante % 60);
          tiempo.text = string.Format("{00:00}:{01:00}", tempMin,tempSeg);
        }
    }
}
