using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalJuego : MonoBehaviour
{
    public GameObject panelVictoria;
    public Button btnVic;

    public GameObject panelDerrota;
    public Button btnDer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ganado()
    {
        panelVictoria.SetActive(true);
        btnVic.Select();
    }

    public void Perdido()
    {
        Time.timeScale = 0;
        panelDerrota.SetActive(true);
        btnDer.Select();
    }

    public void Reintentar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu_Principal");
    }


}
