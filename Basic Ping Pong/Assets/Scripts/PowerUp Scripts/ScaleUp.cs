using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    public int multiplier = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ball"))
        {
            //add particle effect
            collision.GetComponent<BallController>().ScaleUp(multiplier);
            Destroy(gameObject);
        }
    }

    
}
