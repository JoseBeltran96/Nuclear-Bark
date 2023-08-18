using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoObjeto
{
    Pelota,
    Jeringa,
    Bazooka,
    Armor,
    Caramelo,
    Seta
}

public class GeneralObjetos : MonoBehaviour
{
    public TipoObjeto objeto;
    private playerController jugador;
    private Stats hud;

    // Start is called before the first frame update
    void Start()
    {
        jugador = FindObjectOfType<playerController>();
        hud = FindObjectOfType<Stats>();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (objeto)
            {
                case TipoObjeto.Pelota:
                    jugador.speed++; ;
                    hud.ActualizarStats();
                    break;
                case TipoObjeto.Jeringa:
                    jugador.attack++;
                    hud.ActualizarStats();
                    break;
                case TipoObjeto.Bazooka:
                    jugador.attack += 2;
                    jugador.cadencia += 0.4f;
                    hud.ActualizarStats();
                    break;
                case TipoObjeto.Armor:
                    jugador.attack += 1.5f;
                    jugador.speed -= 0.5f;
                    hud.ActualizarStats();
                    break;
                case TipoObjeto.Caramelo:
                    jugador.speed += 2;
                    hud.ActualizarStats();
                    break;
                case TipoObjeto.Seta:
                    jugador.attack /= 2;
                    jugador.cadencia = 0.1f;
                    hud.ActualizarStats();
                    break;
            }
            Destroy(gameObject);
        }
    }
}
