using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    #region Public Variable
    public float delay = 2f;
    public float speed;

    [Header("Effect")]
    public GameObject redBlueEffect;
    public GameObject redGreenEffect;
    public GameObject redWhiteEffect;

    #endregion

    #region Private Variable
    private float currentSpeed;
    private float currentScale = 0.5f;

    private Rigidbody2D rb;
    private GameObject circle;
    private SpriteRenderer defaultColor;

    #endregion

    #region Initialization
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circle = GameObject.Find("Circle");
        defaultColor = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        StartCoroutine(ResetPosition());
    }

    #endregion

    #region Ball Controller
    IEnumerator ResetPosition()
    {
        ResetPowerUp();
        circle.SetActive(true);

        yield return new WaitForSeconds(delay);

        if (!ScoreManager.isGameEnded)
        {
            circle.SetActive(false);
            BallMovement();
        }
    }

    public void BallMovement()
    {
        int rand = Random.Range(-1, 1);

        if (rand != 0)
        {
            Vector2 dir = Vector2.left;
            dir.y = Random.Range(-0.67f, 0.67f);
            rb.velocity = dir.normalized * currentSpeed;
        }
        else
        {
            Vector2 dir = Vector2.right;
            dir.y = Random.Range(-0.67f, 0.67f);
            rb.velocity = dir.normalized * currentSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limiter P1"))
        {
            ScoreManager.scorePlayer2++;
            StartCoroutine(ResetPosition());

        } else if (collision.gameObject.CompareTag("Limiter P2")) {
            ScoreManager.scorePlayer1++;
            StartCoroutine(ResetPosition());
        }

        if(collision.gameObject.CompareTag("Player1"))
        {
            float angle = (transform.position.y - collision.transform.position.y) * 5f;
            Vector2 direction = new Vector2(rb.velocity.x, angle).normalized;
            rb.velocity = direction * currentSpeed;

            GameObject effect = Instantiate(redBlueEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        } 
        
        if (collision.gameObject.CompareTag("Player2"))
        {
            float angle = (transform.position.y - collision.transform.position.y) * 5f;
            Vector2 direction = new Vector2(rb.velocity.x, angle).normalized;
            rb.velocity = direction * currentSpeed;

            GameObject effect = Instantiate(redGreenEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }

        if(collision.gameObject.CompareTag("Obstacles") || collision.gameObject.CompareTag("Limiter"))
        {
            GameObject effect = Instantiate(redWhiteEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    #endregion

    #region Power Up

    void ResetPowerUp()
    {
        transform.position = new Vector2(0, 0);
        rb.velocity = Vector2.zero;
        currentSpeed = speed;
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        defaultColor.color = Color.red;
        
        GameObject obstacle = GameObject.FindGameObjectWithTag("Obstacles");
        Destroy(obstacle);

        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        player1.GetComponent<PlayerController>().currentSpeed = player1.GetComponent<PlayerController>().speed;

        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        player2.GetComponent<PlayerController>().currentSpeed = player2.GetComponent<PlayerController>().speed;
    }

    public void SpeedUp(int speed)
    {
        currentSpeed += speed;
    }

    public void ScaleUp(int multiplier)
    {
        transform.localScale *= multiplier;
    }

    public void ScaleDown(int divider, int speed)
    {
        transform.localScale /= divider;
        currentSpeed += speed;
    }

    #endregion
}
