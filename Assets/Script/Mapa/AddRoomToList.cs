using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoomToList : MonoBehaviour
{
    private RoomTemplate lista;

    // Start is called before the first frame update
    void Start()
    {
        lista = GameObject.FindGameObjectWithTag("Lista").GetComponent<RoomTemplate>();
        lista.rooms.Add(this.gameObject);
    }
}
