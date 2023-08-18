using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{
    public GameObject SalaIncial;
    public GameObject SalaBossFinal;

    public AudioClip musicaBoss;

    private RoomTemplate listaSalas;
    private GameObject Jugador;

    private GameObject[] salasActuales;
    // Start is called before the first frame update
    void Start()
    {
        listaSalas = FindObjectOfType<RoomTemplate>();
        salasActuales = GameObject.FindGameObjectsWithTag("Sala");
        Jugador = GameObject.FindGameObjectWithTag("Player");
    }


    /*Devuelve al jugador a 0,0 y vuelve a generar un piso nuevo
     * aumenta el numero del piso, si este es el 7 generara la sala del boss final
     * */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 posCam = new Vector3(0, 0, -10);

            for (int i = 0; i < salasActuales.Length; i++)
            {
                Destroy(salasActuales[i]);
            }
            listaSalas.rooms.Clear();
            Jugador.transform.position = new Vector3(0, 0, 0);
            Jugador.GetComponent<playerLife>().AñadirContenerdor();
            Camera.main.transform.position = posCam;
            GameObject.FindGameObjectWithTag("PantallaCarga").GetComponent<Animator>().SetTrigger("Carga");
            

            if (listaSalas.numPiso != 6)
            {
                Instantiate(SalaIncial, new Vector3(0, 0, 0), Quaternion.identity);
                listaSalas.GenerarSalas();
                listaSalas.numPiso++;
            }
            else
            {
                Instantiate(SalaBossFinal, new Vector3(10, 0, 0), Quaternion.identity);
                listaSalas.FinalBoss();
                Camera.main.GetComponent<AudioSource>().Stop();
                Camera.main.GetComponent<AudioSource>().clip = musicaBoss;
            }

            for (int i=0; i< GameObject.FindGameObjectsWithTag("Cura").Length; i++)
            {
                Destroy(GameObject.FindGameObjectsWithTag("Cura")[i]);
            }
            
            Destroy(gameObject);

        }
    }
}
