using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle; // accesses paddle class
    private bool hasStarted = false; // game has not started
    private Vector3 paddleToBallVector;  // offset variable
    private Rigidbody2D rb2D; // rigidbody

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start ()
    {
        paddle = GameObject.FindObjectOfType<Paddle>(); // finds Paddle
        paddleToBallVector = this.transform.position - paddle.transform.position; // 3D offset between paddle and ball
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector; // locks ball relative to paddle

            if (Input.GetMouseButtonDown(0)) // 0 - left button clicked to launch ball
            {
                print("Left button clicked");
                hasStarted = true; // game has started
                rb2D.velocity = new Vector2(3f, 10f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f)); // random velocity given to the ball after it collides to something
        print(tweak);

        if (hasStarted)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play(); // plays audio sound on collision
            rb2D.velocity += tweak;
        }
    }
}
