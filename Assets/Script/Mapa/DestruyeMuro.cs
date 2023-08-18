using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruyeMuro : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Muro"))
        {
            Destroy(collision.gameObject);
        }
    }
}
