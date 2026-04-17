using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stative_enemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject bonus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

            if (rb.velocity.y < 0)
            {
                Destroy(enemy);
                rb.velocity = new Vector2(rb.velocity.x, 10f);
                Instantiate(bonus, transform.position, Quaternion.identity);
                EndText.instance.enemiesKilled += 1;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
