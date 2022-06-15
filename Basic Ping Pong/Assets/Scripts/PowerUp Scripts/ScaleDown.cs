using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleDown : MonoBehaviour
{
    public int multiplier = 2;
    public int speed = 5;
    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ball"))
        {
            GameObject effect = Instantiate(pickupEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);

            collision.GetComponent<BallController>().ScaleDown(multiplier, speed);
            Destroy(gameObject);
        }
    }

    
}
