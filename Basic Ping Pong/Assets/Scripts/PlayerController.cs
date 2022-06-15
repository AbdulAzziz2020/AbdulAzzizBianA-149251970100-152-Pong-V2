using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        Player1,
        Player2
    }

    public PlayerState choosePlayer;
    public int speed;
    public float mapWidth;

    private Rigidbody2D rb;

    [HideInInspector]
    public float currentSpeed;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
    }

    private void FixedUpdate()
    {
        if (!ScoreManager.isGameEnded)
        {
            Movement();
        }
    }

    void Movement()
    {
        switch (choosePlayer)
        {
            case PlayerState.Player1:
                float player1 = Input.GetAxis("Controller1") * currentSpeed * Time.deltaTime;
                Vector2 newPositionPlayer1 = rb.position + Vector2.up * player1;
                newPositionPlayer1.y = Mathf.Clamp(newPositionPlayer1.y, -mapWidth, mapWidth);
                rb.MovePosition(newPositionPlayer1);
                break;

            case PlayerState.Player2:
                float player2 = Input.GetAxis("Controller2") * currentSpeed * Time.deltaTime;
                Vector2 newPositionPlayer2 = rb.position + Vector2.up * player2;
                newPositionPlayer2.y = Mathf.Clamp(newPositionPlayer2.y, -mapWidth, mapWidth);
                rb.MovePosition(newPositionPlayer2);
                break;
        }
    }
}
