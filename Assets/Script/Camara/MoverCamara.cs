using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamara : MonoBehaviour
{
    private Vector3 ultimaPos;
    public void CambiarSalaEnfocada(Vector3 objeto)
    {
        if (ultimaPos != objeto)
        {
            ultimaPos = objeto;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(objeto.x, objeto.y, transform.position.z), 20);
        }
        
    }

    IEnumerator Mover()
    {
        
        Time.timeScale = 0;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1;
    }
}
