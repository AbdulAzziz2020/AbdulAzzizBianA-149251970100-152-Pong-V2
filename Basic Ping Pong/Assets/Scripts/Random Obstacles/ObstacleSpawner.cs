using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    
    private int randNumber;

    private void Start()
    {
        randNumber = Random.Range(0, obstacles.Length);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ball"))
        {
            GameObject oldObstacles = GameObject.FindGameObjectWithTag("Obstacles");
            Destroy(oldObstacles);

            Instantiate(obstacles[randNumber], Vector2.zero, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
