using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public int speedUp = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ball"))
        {
            //add particle effect
            collision.GetComponent<BallController>().SpeedUp(speedUp);
            Destroy(gameObject);
        }
    }
}
