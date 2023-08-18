using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public PlayerInput _playerInput;
    private Rigidbody2D rb;
    private Animator animator;
    public float speed = 5f;
    public float attack = 2f;
    public float cadencia;

    private float ultimoDisparo;
    private float horizontal;
    private float vertical;

    private AudioSource sound;

    void Start()
    {
        ultimoDisparo = 0;
        _playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        sound.enabled = true;
    }

    void Update()
    {
        //Velocidad del personaje
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        //Animacion de movimiento
        animator.SetFloat("horizontal", horizontal * speed);
        animator.SetFloat("vertical", vertical * speed);
        animator.SetFloat("speed", rb.velocity.sqrMagnitude);

        
    }



    //Sistema de inputs
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }

    public void upAttack(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time>ultimoDisparo)
        {
            animator.SetTrigger("up");
            ultimoDisparo = Time.time+cadencia;
            sound.Play();
        }
    }

    public void downAttack(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time > ultimoDisparo)
        {
            animator.SetTrigger("down");
            ultimoDisparo = Time.time + cadencia;
            sound.Play();
        }
    }

    public void leftAttack(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time > ultimoDisparo)
        {
            animator.SetTrigger("left");
            ultimoDisparo = Time.time + cadencia;
            sound.Play();
        }
    }

    public void rightAttack(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time > ultimoDisparo)
        {
            animator.SetTrigger("right");
            ultimoDisparo = Time.time + cadencia;
            sound.Play();
        }
    }
}
