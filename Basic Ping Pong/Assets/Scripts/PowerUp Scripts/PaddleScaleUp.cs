using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScaleUp : MonoBehaviour
{
    public enum PlayerState
    {
        player1,
        player2
    }

    public PlayerState choosePlayer;
    public float multiplier = 2f;
    public GameObject player1Effect;
    public GameObject player2Effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            switch (choosePlayer)
            {
                case PlayerState.player1:
                    StartCoroutine(Pickup1(collision));
                    break;

                case PlayerState.player2:
                    StartCoroutine(Pickup2(collision));
                    break;
            }
        }
    }

    IEnumerator Pickup1(Collider2D coll)
    {
        GameObject effect1 = Instantiate(player1Effect, transform.position, Quaternion.identity);
        Destroy(effect1, 1f);

        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        player1.transform.localScale = new Vector3(player1.transform.localScale.x, player1.transform.localScale.y * multiplier, player1.transform.localScale.z);

        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(5f);

        player1.transform.localScale = new Vector3(player1.transform.localScale.x, player1.transform.localScale.y / multiplier, player1.transform.localScale.z);

        Destroy(gameObject);
    }

    IEnumerator Pickup2(Collider2D coll)
    {
        GameObject effect2 = Instantiate(player2Effect, transform.position, Quaternion.identity);
        Destroy(effect2, 1f);

        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        player2.transform.localScale = new Vector3(player2.transform.localScale.x, player2.transform.localScale.y * multiplier, player2.transform.localScale.z);

        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(5f);

        player2.transform.localScale = new Vector3(player2.transform.localScale.x, player2.transform.localScale.y / multiplier, player2.transform.localScale.z);

        Destroy(gameObject);
    }
}
