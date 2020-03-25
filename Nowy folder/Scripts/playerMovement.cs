using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    public Rigidbody2D rb;

    Vector2 move;

   // public Animator animator;

    void Update()
    {
       move.x =  Input.GetAxisRaw("Horizontal");
       move.y =  Input.GetAxisRaw("Vertical");

       // animator.SetFloat("Horizontal", move.x);
       // animator.SetFloat("Vertical", move.y);
       // animator.SetFloat("Speed", move.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+ move * moveSpeed * Time.fixedDeltaTime);

    } 
}
