using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirTransicion : MonoBehaviour
{
    [Header("Salir de la Transicion")]
    private Animator animator;

    [SerializeField] private AnimationClip transicionAlJuego;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        Transition();
    }
    //Animacion
    public void Transition()
    {
        StartCoroutine(CambioEscena());
    }

    IEnumerator CambioEscena()
    {
        animator.SetTrigger("Final");

        yield return new WaitForSeconds(transicionAlJuego.length);

        
    }
}
