using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack; // breaking glass sound
    public Sprite[] hitSprites; // stored as array
    public static int breakableCount = 0;
    public GameObject smoke;
    private int timesHit; // times the ball hits the brick
    private LevelManager levelManager;
    private bool isBreakable;
    

	// Use this for initialization
	void Start ()
    {
        isBreakable = (this.tag == "Breakable"); // checks to see if tag is called breakable
        if (isBreakable)
        {
            breakableCount++;
        }

        timesHit = 0; // initially ball doesnt hit the block
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        
    }
	
	// Update is called once per frame
	void Update ()
     {
        
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 100f); // plays audio sound when ball hits brick
                                                                    // 10f - crack volume
        if (isBreakable)
        {
            HandleHits(); // calls HandleHits method

        }
    }

    void HandleHits() // method
    {
        timesHit++; // timesHit = timesHit + 1
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits) // >= because w might decide to make a superball
        {
            breakableCount--; // decrease breakableCount before destroying
            Debug.Log(breakableCount);
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject); // destroys game object brick
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke() // method dealing with smoke particle system
    {
        GameObject smokePuff = Instantiate(smoke, position: transform.position, rotation: Quaternion.identity) as GameObject; // smoke is generated when a brick is destroyed
        smokePuff.GetComponent<ParticleSystem>().startColor =  gameObject.GetComponent<SpriteRenderer>().color; // setting colour of brick to colour of partical system
    }
    
    void LoadSprites() // method
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex]; // accesses the sprite renderer from the inspector
        }
        else
        {
            Debug.LogError("Brick sprite missing");
        }
    }

    void SimulateWin() // method
    {
        levelManager.LoadNextLevel(); // accesses LoadNextLevel method from levelManager
    }
}
