using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ControladorSalas : MonoBehaviour
{

    public GameObject[] puertas;
    //public GameObject[] listaEnemigos;
    public List<GameObject> list = new List<GameObject>();
    private bool PrimeraVez;

    GameObject salaPref;
    // Start is called before the first frame update
    void Start()
    {
        //PrimeraVez = false;
        obtenerEnemigos();
        StartCoroutine(CambioPuerta(true));
        //CambiarPuertas(true);
    }

    // Update is called once per frame
    void Update()
    {
        obtenerEnemigos();

        if (list.Count == 0)
        {
            //CambiarPuertas(false);
            StartCoroutine(CambioPuerta(false));
        }
    }

    /* Obtiene los enemigos que hay en una sala, 
     * si hay enemigos, al entrar en la sala se cierran 
     * las puertas hasta que se eliminen todos, si no hay
     * las puertas se mantienen abiertas
     * */
    private void obtenerEnemigos()
    {
        list.Clear();

        for (int i=0; i<transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("PrefabSala"))
            {
                salaPref = transform.GetChild(i).gameObject;
                
            }
        }

        if (salaPref != null)
        {
            for (int i=0; i<salaPref.transform.childCount; i++)
            {
                if (salaPref.transform.GetChild(i).CompareTag("Enemigo"))
                {
                    list.Add(salaPref.transform.GetChild(i).gameObject);
                    
                }
            }
        }
        for (int i = 0; i < list.Count; i++)
        {
            list[i].gameObject.SetActive(true);
        }

    }

    /* Abre o cierra las puertas
     * */
    IEnumerator CambioPuerta(bool estado)
    {
        yield return new WaitForSeconds(0.7f);
        for (int i = 0; i < puertas.Length; i++)
        {
            puertas[i].GetComponent<Puertas>().cambiarEstado(estado);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.CompareTag("Player"))
        {
            for (int i=0; i<list.Count; i++)
            {
                
            }
        }*/
    }
}
