using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCollider : MonoBehaviour {

    private LevelManager levelManager; // calls out for LevelManager script

	void OnCollisionEnter2D(Collision2D collision) // void - prints nothing
                                                   // OnCollisionEnter2D - method
                                                   //  use type 'Collision2D' for collision
                                                   // collision - instance name
    {
        print("Collision");
    }

    void OnTriggerEnter2D(Collider2D trigger)   // OnTriggerEnter2D - method   
                                                // use type 'Collider2D' for trigger  
                                                // trigger - instance name
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>(); // looks for LevelManager
        levelManager.LoadLevel("Loose"); // redirects to the loose screen
    }
}
