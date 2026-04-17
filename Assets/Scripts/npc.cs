using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] Animator anim;
    [SerializeField] GameObject loseMenu;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();   
        anim.SetBool("1_Move", true);

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Flip"))
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("1_Move", false);
            anim.SetTrigger("2_Attack");
            speed = 0;
            StartCoroutine(AttackDelay());
        }
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 0f;
        loseMenu.SetActive(true);
    }


        void Flip()
    {
        speed *= -1;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
