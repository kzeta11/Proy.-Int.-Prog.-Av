using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
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
            transform.localScale = new Vector2(2, 2);
            anim.SetBool("IsWalking", true);
        }
        else if (mueveIzquierda)
        {
            transform.localScale = new Vector2(-2, 2);
            anim.SetBool("IsWalking", true);
        }
        else
        {
            // Al no detectar movimiento válido, pasamos a modo Idle
            anim.SetBool("IsWalking", false);
        }
    }

}