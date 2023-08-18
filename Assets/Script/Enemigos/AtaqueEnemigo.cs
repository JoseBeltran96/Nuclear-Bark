using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    [SerializeField] Transform PuntoDisparo;
    [SerializeField] GameObject bala;
    [SerializeField] float velocidadBala;
    [SerializeField] float cadencia;
    private GameObject Player;
    private AudioSource audio;
    public float rangoDisparo;

    private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        canShoot = true;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) <= rangoDisparo && canShoot)
        {
            StartCoroutine(Disparo());
        }
    }

    IEnumerator Disparo()
    {
        Vector3 dir = Player.transform.position - transform.position;

        
        GameObject bal = Instantiate(bala, PuntoDisparo.position, Quaternion.identity);
        Vector2 direccion = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y).normalized;
        bal.GetComponent<Rigidbody2D>().AddForce(new Vector2(direccion.x*velocidadBala, direccion.y*velocidadBala));
        audio.Play();
        Destroy(bal, 6);
        canShoot = false;
        yield return new WaitForSeconds(cadencia);
        canShoot = true;
    }


}
