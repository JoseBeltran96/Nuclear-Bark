using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraBoss : MonoBehaviour
{
    public Slider Barra;
    public float vida;
    public bool isSniper;

    [SerializeField] Vector3 ultimaPos;

    [SerializeField] GameObject dropVida;
    private Rigidbody2D rb;
    private Animator animator;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 dir = player.transform.position - ultimaPos;



        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);


        ultimaPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /* Controla si el enemigo ha colisionado con 
     * el ataque del jugador, si lo ha hecho realiza la 
     * animacion de daño y reduce su vida.
     * Tambien calcula la direccion a la que camina para 
     * usar la animacion de daño correspondiente
     * */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladrido"))
        {
            Vector3 dir = transform.position - ultimaPos;

            float dano = FindObjectOfType<playerController>().attack;
            vida -= dano;
            if (vida <= 0)
            {
                animator.SetTrigger("Dead");
                if (Random.Range(0, 100) < 10)
                    Instantiate(dropVida, transform.position, Quaternion.identity);
                ActualizarBarra(vida);
                FindObjectOfType<FinalJuego>().Ganado();
                Destroy(gameObject, 0.3f);

            }
            else
            {
                ActualizarBarra(vida);
                if (dir.x > dir.y)
                {
                    if (dir.x > 0)
                    {
                        animator.SetTrigger("DmgRight");
                    }
                    else
                    {
                        animator.SetTrigger("DmgLeft");
                    }
                }
                else
                {
                    if (dir.y > 0)
                    {
                        animator.SetTrigger("DmgUp");
                    }
                    else
                    {
                        animator.SetTrigger("DmgDown");
                    }
                }
            }



        }
    }

    public void ActualizarBarra(float Vida)
    {
        Barra.value = Vida;
    }
}
