using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject panelOpciones;
    public Button botonVolver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Pausar(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Time.timeScale = 0;
            panelOpciones.SetActive(true);
            botonVolver.Select();
        }
    }


    public void Reanudar()
    {
        Time.timeScale = 1;
        panelOpciones.SetActive(false);

    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu_Principal");
    }
}
