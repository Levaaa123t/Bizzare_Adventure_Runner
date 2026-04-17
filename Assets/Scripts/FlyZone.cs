using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb;
            rb = collision.GetComponent<Rigidbody2D>();
            rb.gravityScale = -5f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb;
            rb = collision.GetComponent<Rigidbody2D>();
            rb.gravityScale = 7f;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
