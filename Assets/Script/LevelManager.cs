using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name) // method to load a level
    {
        Debug.Log("Level load requested " + name); // checks to verify if button is pressed
        Brick.breakableCount = 0; // resets breakableCount after loading new level
        Application.LoadLevel(name); // changes the scene when button is pressed
    }

    public void RestartLevel() // method to load a level
    {
        Debug.Log("Level load requested " + name); // checks to verify if button is pressed
        Brick.breakableCount = 0; // resets breakableCount after loading new level
        Application.LoadLevel(Application.loadedLevel -  2); // changes the scene when button is pressed
    }

    public void QuitRequest() // method to quit
    {
        Debug.Log(message: "I want to Quit! "); // checks to verify if button is pressed
        Application.Quit(); // quits the application
    }

    public void LoadNextLevel() // method to load next level
    {
        Brick.breakableCount = 0;
        Application.LoadLevel(Application.loadedLevel + 1); // loads the next level according to index number from the build settings
    }

    public void BrickDestroyed() // method to see if last brick is destroyed to load next scene
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
