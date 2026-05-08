using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocidad = 5f;
    public float fuerzaSalto = 4f;
    public CheckGround checkGround;
    private Animator anim;
    private Rigidbody2D rb;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Los inputs de una sola pulsación (GetKeyDown) siempre deben ir en Update
        MovimientoSalto();
    }


    void FixedUpdate()
    {
        MovimientoCaminar();
    }

    void MovimientoCaminar()
    {
        bool mueveDerecha = Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A);
        bool mueveIzquierda = Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D);

        if (mueveDerecha)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
            transform.localScale = new Vector2(2, 2);
            anim.SetBool("IsWalking", true);
        }
        else if (mueveIzquierda)
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            transform.localScale = new Vector2(-2, 2);
            anim.SetBool("IsWalking", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            // Al no detectar movimiento válido, pasamos a modo Idle
            anim.SetBool("IsWalking", false);
        }
    }

    void MovimientoSalto()
    {
     

        // Detectamos la tecla de salto y verificamos si está tocando el suelo
        if (Input.GetKeyDown(KeyCode.Space) && checkGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            //anim.SetTrigger("Idle");
        }
    }
}