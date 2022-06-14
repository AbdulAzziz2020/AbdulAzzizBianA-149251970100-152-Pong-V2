using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedUp : MonoBehaviour
{
    public enum PlayerState
    {
        player1,
        player2
    }

    public PlayerState choosePlayer;
    public float speed = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ball"))
        {
            switch(choosePlayer)
            {
                case PlayerState.player1:
                    GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
                    player1.GetComponent<PlayerController>().currentSpeed += speed;
                    Destroy(gameObject);
                    break;

                case PlayerState.player2:
                    GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
                    player2.GetComponent<PlayerController>().currentSpeed += speed;
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
