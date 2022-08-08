using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Vector3 velocity;
    float speedAmount = 5f;
    float jumpAmount = 6.9f;
    int coinAmount = 0;
    bool movementControl = true;
    UIScript uiScript;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        uiScript.ShowGameOverButtons(false);
    }
    private void Awake()
    {
        uiScript = GameObject.FindObjectOfType<UIScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (movementControl)
        {
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
            transform.position += velocity * speedAmount * Time.deltaTime;
            if (Input.GetButtonDown("Jump") && Mathf.Approximately(rigidbody2D.velocity.y, 0))
            {
                rigidbody2D.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            }
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        else
        {
            Destroy(rigidbody2D);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            coinAmount += 1;
            uiScript.UpdateScore(coinAmount);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Waters"))
        {
            uiScript.ShowGameOverButtons(true);
            movementControl = false;

        }
        if (collision.gameObject.CompareTag("Enemies"))
        {
            uiScript.ShowGameOverButtons(true);
            movementControl = false;

        }
        if (collision.gameObject.CompareTag("Chests"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
        if (collision.gameObject.CompareTag("Traps"))
        {
            uiScript.ShowGameOverButtons(true);
            movementControl = false;
        }
    }
}
