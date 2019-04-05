using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null; // static - use static when its one of a kind
                                        // null - nothing

    void Awake() // Awake - gets executed before Start()
    {

        if (instance != null)
        {
            Destroy(gameObject); // destroyes gameobject i.e. MusicPlayer in this case
        }

        else
        {
            instance = this; // this - class we are currently working on

            GameObject.DontDestroyOnLoad(gameObject); // make sure gameOject doesnt get destroyed after next scene is loaded
                                                      // gameOject - in this case is the Music Player

            print("Destroyed music player duplicates");
        }
    }


    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
