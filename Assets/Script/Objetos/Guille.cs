using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guille : MonoBehaviour
{    
    private playerController jugador;
    private Stats hud;
    private AudioSource sound;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        jugador = FindObjectOfType<playerController>();
        hud = FindObjectOfType<Stats>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int rnd = Random.Range(0, 10);
            if (rnd >= 0 && rnd < 3)
            {
                jugador.attack++;
                hud.ActualizarStats();

            }
            else if (rnd >= 3 && rnd < 6)
            {
                jugador.speed++;
                hud.ActualizarStats();
            }
            else if (rnd >= 6 && rnd < 9)
            {
                jugador.cadencia -= 0.2f;
                hud.ActualizarStats();
            }
            else
            {
                jugador.speed++;
                jugador.cadencia -= 0.2f;
                jugador.attack++;
                sound.Play();
                hud.ActualizarStats();
            }
            sprite.enabled = false;
            Destroy(gameObject, 1.5f);
        }
    }
}
