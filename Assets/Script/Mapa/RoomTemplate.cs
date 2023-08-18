using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RoomTemplate : MonoBehaviour
{
    [Header("Templates muros de las habitaciones")]
    public GameObject[] Abajo;
    public GameObject[] Arriba;
    public GameObject[] Derecha;
    public GameObject[] Izquierda;

    [Header("Prefabs de salas")]
    public GameObject[] PrefabSalas;


    [Header("Lista de objetos")]
    public List<GameObject> Objetos;

    [Header("PathFinder")]
    public GameObject pathFinder;

    public List<GameObject> rooms;

    public GameObject escalera;

    public GameObject PantallaCarga;

    private int salaObjeto;

    public int numPiso;

    [Header("Perro")]

    public GameObject player;



    private void Start()
    {
        player.GetComponent<playerController>().enabled = false;
        Invoke("DefinirSala", 5f);
        //numPiso = 0;
    }


    /*Rellena las salas creadas con las salas precreadas y las rellena con ellas
    Genera la escalera en la ultima sala de la lista y el objeto en una sala aleatoria*/
    void DefinirSala()
    {
        //Vector3 esc = new Vector3(rooms[rooms.Count - 1].transform.position.x, rooms[rooms.Count - 1].transform.position.y - 3, 0);
        Instantiate(escalera, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
        salaObjeto = Random.Range(0, rooms.Count - 2);
        Instantiate(Objetos[Random.Range(0, Objetos.Count-1)], rooms[salaObjeto].transform.position, Quaternion.identity);

        for (int i=0; i<rooms.Count-1; i++)
        {
            if (i != salaObjeto)
            {
                Instantiate(PrefabSalas[Random.Range(0, PrefabSalas.Length)], rooms[i].transform.position, Quaternion.identity).transform.parent = rooms[i].transform;
                
            }
        }
        pathFinder.GetComponent<AstarPath>().Scan();
        PantallaCarga.GetComponent<Animator>().SetTrigger("Final");
        player.GetComponent<playerController>().enabled = true;

    }

    public void GenerarSalas()
    {
        Invoke("DefinirSala", 5f);
    }

    public void FinalBoss()
    {
        PantallaCarga.GetComponent<Animator>().SetTrigger("Final");
        pathFinder.GetComponent<AstarPath>().Scan();
    }
}
