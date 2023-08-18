using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura : MonoBehaviour
{
    public GameObject anim;
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
            if (!collision.GetComponent<playerLife>().maxVida())
            {
                collision.GetComponent<playerLife>().DarVida();
                GameObject a =Instantiate(anim, transform.position, Quaternion.identity);
                Destroy(a, 0.5f);
                Destroy(gameObject);
            }
        }
    }
}
