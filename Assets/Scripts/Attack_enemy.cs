using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_enemy : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject loseMenu;
    bool isAttacking = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // isAttacking = true;
            anim.SetTrigger("2_Attack");
            StartCoroutine(AttackDelay());
        }
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        Time.timeScale = 0f;
        loseMenu.SetActive(true);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
