using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup_finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(588, 33, 0);
            EndText.instance.isFinished = true;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
