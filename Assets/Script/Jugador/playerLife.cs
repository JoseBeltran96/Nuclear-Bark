using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLife : MonoBehaviour
{
    public float maxHP;
    public float actualHP;

    public GameObject vidas;
    public GameObject contenedorVidas;
    public GameObject medioCorazon;

    public GameObject panelVidas;
    public Vector3 ultimaPos;

    private List<GameObject> listaVidas;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        listaVidas = new List<GameObject>();
        maxHP = actualHP = 6;
        for (int i = 0; i < maxHP; i += 2)
        {
            GameObject v = Instantiate(vidas, panelVidas.transform.position, Quaternion.identity);
            v.transform.parent = panelVidas.transform;
            listaVidas.Add(v);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /* Añade 2 punto de vida(1 corazon) al jugador 
     * y actualiza los corazones del HUD 
     * */
    public void DarVida()
    {
        if (actualHP < maxHP)
        {
            actualHP += 2;
            if (actualHP > maxHP)
            {
                actualHP = maxHP;
            }
            Destroy(listaVidas[listaVidas.Count - 1]);
            listaVidas.Remove(listaVidas[listaVidas.Count - 1]);

            GameObject v = Instantiate(vidas, panelVidas.transform.position, Quaternion.identity);
            v.transform.parent = panelVidas.transform;
            v.transform.SetAsFirstSibling();
            listaVidas.Insert(0, v);
        }
        else
        {
            return;
        }
    }

    /* Reduce 1 punto de vida(0.5 corazon) al jugador
     * y actualiza el HUD
     * */
    public void QuitarVida()
    {
        if (actualHP > 1)
        {
            actualHP--;
            animHurt();
            if (actualHP % 2 == 0)
            {
                int inde = findLastHP() + 1;
                Destroy(listaVidas[inde]);
                listaVidas.Remove(listaVidas[inde]);

                GameObject v = Instantiate(contenedorVidas, panelVidas.transform.position, Quaternion.identity);
                v.transform.parent = panelVidas.transform;
                listaVidas.Add(v);
            }
            else
            {
                int inde = findLastHP();
                Destroy(listaVidas[inde]);
                listaVidas.Remove(listaVidas[inde]);

                GameObject v = Instantiate(medioCorazon, panelVidas.transform.position, Quaternion.identity);
                v.transform.parent = panelVidas.transform;
                v.transform.SetSiblingIndex(inde);
                listaVidas.Insert(inde, v);

            }

        }
        else
        {
            FindObjectOfType<FinalJuego>().Perdido();
            return;
        }
    }

    public void QuitarVidaX2()
    {
        if (actualHP > 2)
        {
            actualHP -= 2;
            animHurt();

            int inde = findLastHP();
            Destroy(listaVidas[inde]);
            listaVidas.Remove(listaVidas[inde]);

            GameObject v = Instantiate(contenedorVidas, panelVidas.transform.position, Quaternion.identity);
            v.transform.parent = panelVidas.transform;
            listaVidas.Add(v);


        }
        else
        {
            FindObjectOfType<FinalJuego>().Perdido();
            return;
        }
    }

    public void AñadirContenerdor()
    {
        maxHP += 2;

        GameObject v = Instantiate(contenedorVidas, panelVidas.transform.position, Quaternion.identity);
        v.transform.parent = panelVidas.transform;
        listaVidas.Add(v);

        DarVida();
    }

    /* Encuentra el último corazon entero del HUD
     * para dar correspondencia a la actualizacion de 
     * la vida en el HUD
     * */
    private int findLastHP()
    {
        int index = 0;
        for (int i = 0; i < listaVidas.Count; i++)
        {
            if (listaVidas[i].CompareTag("Corazon"))
            {
                index = i;
            }
            else
            {
                break;
            }
        }
        return index;
    }

    public bool maxVida()
    {
        if (actualHP == maxHP)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /* Realiza la animacion de daño del jugador 
     * dependiendo de la direccion del movimiento
     * */
    private void animHurt()
    {
        Vector3 dir = transform.position - ultimaPos;
        if (Mathf.Abs( dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0)
            {
                animator.SetTrigger("HurtRight");
            }
            else
            {
                animator.SetTrigger("HurtLeft");
            }
        }
        else
        {
            if (dir.y > 0)
            {
                animator.SetTrigger("HurtUp");
            }
            else
            {
                animator.SetTrigger("HurtDown");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

}
