using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public TextMeshProUGUI TxtAtq;
    public TextMeshProUGUI TxtVel;
    public TextMeshProUGUI TxtCd;

    private playerController control;
    // Start is called before the first frame update
    void Start()
    {
        control = FindObjectOfType<playerController>();
        ActualizarStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualizarStats()
    {
        TxtAtq.text = control.attack.ToString();
        TxtVel.text = control.speed.ToString();
        TxtCd.text = control.cadencia.ToString();
    }
}
