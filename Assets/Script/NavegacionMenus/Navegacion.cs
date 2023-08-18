using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegacion : MonoBehaviour
{
    public GameObject panelOpciones;
    public GameObject panelControles;
    public GameObject panelSonidos;
    public GameObject LoadingScreen;

    
    void Start()
    {
        
    }

    //CODIFICACION DEL MENU PRINCIPAL
    public void Jugar()
    {
        
        Time.timeScale = 1;
        LoadingScreen.gameObject.SetActive(true);

    }

    public void PanelSonido()
    {
        panelSonidos.gameObject.SetActive(true);
        panelOpciones.gameObject.SetActive(false);
    }
    public void PanelOpciones()
    {
        panelOpciones.gameObject.SetActive(true);
    }

    public void PanelControles()
    {
        panelControles.gameObject.SetActive(true);
        panelOpciones.gameObject.SetActive(false);
    }
    public void cerrar()
    {
        if (GameObject.FindGameObjectWithTag("exitOpciones"))
        {
            panelOpciones.gameObject.SetActive(false);
        }
        else if (GameObject.FindGameObjectWithTag("exitControles"))
        {
            panelControles.gameObject.SetActive(false);
            panelOpciones.gameObject.SetActive(true);
        }
        else if (GameObject.FindGameObjectWithTag("exitSonidos"))
        {
            panelSonidos.gameObject.SetActive(false);
            panelOpciones.gameObject.SetActive(true);
        }
    }

    //SALIR DEL JUEGO
    public void exit()
    {
        Application.Quit();

    }
    
}