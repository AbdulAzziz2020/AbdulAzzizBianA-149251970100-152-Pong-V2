using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleDown : MonoBehaviour
{
    public int multiplier = 2;
    public int speed = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ball"))
        {
            //add particle effect
            collision.GetComponent<BallController>().ScaleDown(multiplier, speed);
            Destroy(gameObject);
        }
    }

    
}
