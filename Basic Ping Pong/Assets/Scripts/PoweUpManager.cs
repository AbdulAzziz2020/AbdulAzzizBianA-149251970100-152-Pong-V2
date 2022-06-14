using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweUpManager : MonoBehaviour
{
    [Header("Area Spawn")]
    public Collider2D areaSpawn;

    [Header("Object To Spawn")]
    public int maxObjectToSpawn;
    public GameObject[] objectToSpawn;
    public float timeBetweenSpawn;
    private float timeSpawn;

    private void Start()
    {
        timeSpawn = 5f;
    }

    private void Update()
    {
        if(!ScoreManager.isGameEnded)
        {
            if (timeSpawn < 0)
            {
                
                for (int i = 0; i < maxObjectToSpawn; i++)
                {
                    Destroy(GameObject.FindGameObjectWithTag("Power Up"));
                    int randomObject = Random.Range(0, objectToSpawn.Length);
                    float randomAreaX = Random.Range(areaSpawn.bounds.min.x, areaSpawn.bounds.max.x);
                    float randomAreaY = Random.Range(areaSpawn.bounds.min.y, areaSpawn.bounds.max.y);
                    Vector2 newPosition = new Vector2(randomAreaX, randomAreaY);

                    Instantiate(objectToSpawn[randomObject], newPosition, Quaternion.identity);
                }

                timeSpawn = timeBetweenSpawn;
            }
            else
            {
                timeSpawn -= Time.deltaTime;
            }
        }
    }

}
