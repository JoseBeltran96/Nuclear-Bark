using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarBoss : MonoBehaviour
{
    public GameObject BarraHP;
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BarraHP.SetActive(true);
            Boss.SetActive(true);
            Camera.main.GetComponent<AudioSource>().Play();
        }
    }
}
