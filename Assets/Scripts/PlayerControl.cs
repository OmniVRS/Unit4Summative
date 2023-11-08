using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody2D playerRb;
    public GameObject powerupIndicator;
    private float horizontalInput;
    public float moveSpeed;
    public float jumpForce;
    private bool isOnGround = true;
    private float powerupMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce * powerupMultiplier, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    private void FixedUpdate()
    {
        playerRb.AddForce(Vector2.right * horizontalInput * moveSpeed * powerupMultiplier);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Powerup"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(PowerupControl());
        }
    }

    IEnumerator PowerupControl()
    {
        float savedMultiplier = powerupMultiplier;
        float savedMass = playerRb.mass;
        playerRb.mass = 1000000;
        powerupMultiplier = 1000000;
        powerupIndicator.SetActive(true);
        yield return new WaitForSeconds(10);
        powerupIndicator.SetActive(false);
        powerupMultiplier = savedMultiplier;
        playerRb.mass = savedMass;

    }
}
