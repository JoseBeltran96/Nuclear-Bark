using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public Sprite[] EstadosPuertas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarEstado(bool est)
    {
        GetComponent<BoxCollider2D>().enabled = est;
        if (est)
        {
            GetComponent<SpriteRenderer>().sprite = EstadosPuertas[1];
        } else
        {
            GetComponent<SpriteRenderer>().sprite = EstadosPuertas[0];
        }
    }
}
