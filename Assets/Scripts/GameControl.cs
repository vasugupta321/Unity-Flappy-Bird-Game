using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance; //Static allows us to associate this with class and make it accesible to any other scripts easily
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -2.0f;

    private int score = 0;

	// Awake called before start. We make sure GameControl is set up before processes in Start function by using Singleton Pattern
	void Awake () {
		if (instance == null) // if we dont have any other GameControl then our instance is this GameControl
        {
            instance = this;
        }
        else if (instance != this) //if  our instance is not this GameControl then we destroy game object
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void MarioScored()
    {
        if (gameOver)
        {
            return; //we exit function without doing anything
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void MarioDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
