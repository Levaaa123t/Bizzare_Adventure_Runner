using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    float patroalTimer;
    protected Rigidbody2D rb;


    void Move()
    {
        rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
        patroalTimer += Time.deltaTime;
        if (patroalTimer > 2)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            patroalTimer = 0;

        }
        else
        {
        transform.localScale = new Vector3(1, 1, 1);
            speed = -speed;
        }
           
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   void FixedUpdate()
    {
        Move();
    }
    void Update()
    {
        
    }
}
