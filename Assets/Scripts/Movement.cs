using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp_ren;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpSpeed;
    Vector2 movement;
    bool isGrounded = true;
    [SerializeField] string[] groundTags;
    [SerializeField] GameObject pickupEffect;
    [SerializeField] GameObject effect_time;
    [SerializeField] GameObject player;
    bool isEffectActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp_ren = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // движение по горизонтали
        movement.x = Input.GetAxisRaw("Horizontal");

        // прыжок
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        switch (Input.GetAxisRaw("Horizontal"))
        {
            case -1:
                sp_ren.flipX = true;
                break;
            case 1:
                sp_ren.flipX = false;
                break;
        }
        if (isEffectActive)
        {
            isEffectActive = false;
            Vector3 offset = new Vector3(0, 0.5f, 0);
            GameObject effect_time_inst = Instantiate(effect_time, player.transform.position + offset, Quaternion.identity, player.transform);
            Destroy(effect_time_inst, 5f);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string tag in groundTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                isGrounded = true;
                break;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food_Speed"))
        {
            speed += 2.5f;
            Destroy(collision.gameObject);
            GameObject effect = Instantiate(pickupEffect, collision.transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            EndText.instance.applesCollected += 1;
        }
        if (collision.gameObject.CompareTag("Food_Jump"))
            {
            jumpSpeed += 2.5f;
            Destroy(collision.gameObject);
            GameObject effect = Instantiate(pickupEffect, collision.transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            EndText.instance.cherrysCollected += 1;
        }
        if (collision.gameObject.CompareTag("Food_time"))
        {
            StartCoroutine(SpeedBoostCoroutine());
            Destroy(collision.gameObject);
            GameObject effect = Instantiate(pickupEffect, collision.transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            isEffectActive = true;
            EndText.instance.bonusesCollected += 1;
        }
    }
    IEnumerator SpeedBoostCoroutine()
    {
        speed += 5f;
        jumpSpeed += 5f;
        yield return new WaitForSecondsRealtime(5f);
        speed -= 5f;
        jumpSpeed -= 5f;
    }
}
