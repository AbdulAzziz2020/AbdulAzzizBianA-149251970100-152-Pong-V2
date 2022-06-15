using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerV2 : MonoBehaviour
{
    public int speed;

    private int currentSpeed;
    private Vector3 originScale = new Vector3(0.5f, 0.5f, 0.5f);
    private Rigidbody2D rigid;
    private GameObject circle;

    private void Start()
    {
        currentSpeed = speed;
        rigid = GetComponent<Rigidbody2D>();
    }

    void Reset()
    {
        transform.localPosition = Vector2.zero;
    }

    void BallMovement()
    {
        
    }
}
