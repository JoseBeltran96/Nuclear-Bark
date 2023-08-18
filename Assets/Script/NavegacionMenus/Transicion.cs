using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transicion : MonoBehaviour
{
    [Header("Transicion")]
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
        animator.SetTrigger("Iniciar");

        yield return new WaitForSeconds(transicionAlJuego.length);

        SceneManager.LoadScene(1);
    }
}
