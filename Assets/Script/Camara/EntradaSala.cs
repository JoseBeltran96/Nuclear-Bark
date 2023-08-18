using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaSala : MonoBehaviour
{
    /*Mueve la camara para enfocar la sala que 
     * se acaba de acceder y activa el script que controla las 
     * puertas y los enemigos
     * */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoverCamara camara = FindObjectOfType<MoverCamara>();
            camara.CambiarSalaEnfocada(transform.position);
            transform.GetComponent<ControladorSalas>().enabled = true;
        }
    }
}
