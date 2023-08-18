using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openSide;
    //1 Necesita abierto abajo
    //2 Necesita abierto arriba
    //3 Necesita abierto derecha
    //4 Necesita abierto izquierda 

    private RoomTemplate lista;
    private int num;
    private bool Spawned = false;

    void Start()
    {
        lista = GameObject.FindGameObjectWithTag("Lista").GetComponent<RoomTemplate>();
        Invoke("Spawn", Random.Range(0.1f, 0.8f));
    }

    /*Genera la siguiente sala dependiendo de la puerta necesaria que tenga que 
     * estar abierta. Si el numero de pisos total es mayor al numero del piso por 
     * el numero minimo de salas(5), solo generara salas que no generan mas salas para
     * finalizar el piso
     * */
    void Spawn()
    {
        if (Spawned == false)
        {
            if (openSide == 1) //Necesita Abajo
            {
                if (lista.rooms.Count >= lista.numPiso * 4)
                {
                    Instantiate(lista.Abajo[0], transform.position, lista.Abajo[0].transform.rotation);
                }
                else
                {
                    num = Random.Range(1, lista.Abajo.Length);
                    Instantiate(lista.Abajo[num], transform.position, lista.Abajo[num].transform.rotation);
                }
                
            }
            else if (openSide == 2) //Necesita Arriba
            {
                if (lista.rooms.Count >= lista.numPiso * 4)
                {
                    Instantiate(lista.Arriba[0], transform.position, lista.Arriba[0].transform.rotation);
                }
                else
                {
                    num = Random.Range(1, lista.Arriba.Length);
                    Instantiate(lista.Arriba[num], transform.position, lista.Arriba[num].transform.rotation);
                }
                
            }
            else if (openSide == 3) //Necesita Derecha
            {
                if (lista.rooms.Count >= lista.numPiso * 4)
                {
                    Instantiate(lista.Derecha[0], transform.position, lista.Derecha[0].transform.rotation);
                }
                else
                {
                    num = Random.Range(1, lista.Derecha.Length);
                    Instantiate(lista.Derecha[num], transform.position, lista.Derecha[num].transform.rotation);
                }
                
            }
            else if (openSide == 4) //Necesita Izquierda
            {
                if (lista.rooms.Count >= lista.numPiso * 4)
                {
                    Instantiate(lista.Izquierda[0], transform.position, lista.Izquierda[0].transform.rotation);
                }
                else
                {
                    num = Random.Range(1, lista.Izquierda.Length);
                    Instantiate(lista.Izquierda[num], transform.position, lista.Izquierda[num].transform.rotation);
                }
                
            }
            Spawned = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sala"))
        {
            Destroy(gameObject);
        }
    }


}
