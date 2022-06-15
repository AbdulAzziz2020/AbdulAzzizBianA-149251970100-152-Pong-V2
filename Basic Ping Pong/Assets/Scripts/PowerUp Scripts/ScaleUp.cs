using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    public int multiplier = 3;
    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ball"))
        {
            GameObject effect = Instantiate(pickupEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);

            collision.GetComponent<BallController>().ScaleUp(multiplier);
            Destroy(gameObject);
        }
    }

    
}
