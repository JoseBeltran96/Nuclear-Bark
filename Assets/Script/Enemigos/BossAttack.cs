using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject Rayo;
    public GameObject Nube;
    public float CD_Rayo;
    public float CD_Nube;
    public float rangoDisparo;

    private bool CanRayo;
    private bool CanNube;

    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        CanRayo = true;
        CanNube = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (CanRayo)
        {
            CanRayo = false;
            StartCoroutine(AtqRayo());
        } 

        if (CanNube && Vector2.Distance(player.transform.position, transform.position) <= rangoDisparo)
        {
            CanNube = false;
            StartCoroutine(AtqNube());
        }
    }

    IEnumerator AtqRayo()
    {
        GameObject rayo = Instantiate(Rayo, player.transform.position, Quaternion.identity);
        Destroy(rayo, 1);
        yield return new WaitForSeconds(CD_Rayo);
        CanRayo = true;
    }

    IEnumerator AtqNube()
    {
        GameObject nube = Instantiate(Nube, transform.position, Quaternion.identity);
        Destroy(nube, 1);
        yield return new WaitForSeconds(CD_Nube);
        CanNube = true;
    }
}
