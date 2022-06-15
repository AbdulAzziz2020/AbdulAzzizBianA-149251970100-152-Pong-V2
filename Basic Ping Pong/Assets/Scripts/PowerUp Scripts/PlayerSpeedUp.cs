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
    public int speed = 5;
    public GameObject blueEffect;
    public GameObject greenEffect;

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

                    GameObject effect1 = Instantiate(blueEffect, transform.position, Quaternion.identity);
                    Destroy(effect1, 1f);
                    break;

                case PlayerState.player2:
                    GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
                    player2.GetComponent<PlayerController>().currentSpeed += speed;
                    Destroy(gameObject);

                    GameObject effect2 = Instantiate(blueEffect, transform.position, Quaternion.identity);
                    Destroy(effect2, 1f);
                    break;
            }
        }
    }
}
