using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    private Ball ball;

	// Use this for initialization
	void Start ()
    {
        ball = GameObject.FindObjectOfType<Ball>(); // looks for Ball
        print(ball);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!autoPlay) // if not autoplay, then move paddle with mouse
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
	}

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(8f, this.transform.position.y, 0f); // vector3 - predefined class with (x,y,z) coordinates
                                                                            // paddlePos - variable
                                                                            // new Vector3 - creates new vector3
                                                                            // 8f - initial float value of 8
                                                                            // this.transform.position.y - keeps the y position in place


        Vector3 ballPos = ball.transform.position;

        paddlePos.x = Mathf.Clamp(ballPos.x, -1.5f, 17.5f); // Math.Clamp - sets constrains for the paddle movement
                                                                  // mousePosInBlocks - int value
                                                                  // -1.5f - minimum value
                                                                  // 17.5f - maximum value

        this.transform.position = paddlePos; // this - instance of current script i.e. paddle object
                                             // this.transform.position - transforms x-position of paddle according to x-position of mouse
    }

    void MoveWithMouse() // method when paddle controoled by mouse
    {
        Vector3 paddlePos = new Vector3(8f, this.transform.position.y, 0f); 

        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16; // mousePosInBlocks - variable
                                                                            // Input.mousePosition.x - logs out the x-position of mouse
                                                                            // Screen.width - logs out the width of the game screen

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, -1.5f, 17.5f); 

        this.transform.position = paddlePos; // this - instance of current script i.e. paddle object
                                             // this.transform.position - transforms x-position of paddle according to x-position of mouse

    }
}
