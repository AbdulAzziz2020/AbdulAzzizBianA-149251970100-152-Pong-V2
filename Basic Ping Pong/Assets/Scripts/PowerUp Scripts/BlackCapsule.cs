using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCapsule : MonoBehaviour
{
    public Color blackColor;

    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ball"))
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);

            collision.GetComponent<SpriteRenderer>().color = blackColor;

            Destroy(gameObject);
        }
    }
}
