using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour {

    public int pipePoolSize = 5;
    public GameObject pipePrefab; //game object to instatiate
    public float spawnRate = 4f; //how often we position new pipe in front of player from the pool
    public float pipeMin = -1f;
    public float pipeMax = 3.5f;

    private GameObject[] pipes; //array to hold pipes
    private Vector2 objectPoolPosition = new Vector2(-15, -25); //position off screen
    private float timeSinceLastSpawned; //store how much time passed since last put column in front of player
    private float spawnXPosition = 10;
    private int currentPipe = 0;

	// Use this for initialization
	void Start () {
        pipes = new GameObject[pipePoolSize]; //initialize empty array game object with piperPoolSize # of slots
        for(int i = 0; i < pipePoolSize; i++) //loop through number of pipes
        {
            //instantiating object, casting to game object and storing it in array 
            //for each slot in array. Quaternion uses rotation of prefab
            pipes[i] = (GameObject)Instantiate(pipePrefab, objectPoolPosition, Quaternion.identity); 
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawned += Time.deltaTime; //time taken to render last frame
        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPoistion = Random.Range(pipeMin, pipeMax);//generate random offsets vertically to poisition pipes
            pipes[currentPipe].transform.position = new Vector2(spawnXPosition, spawnYPoistion); //fixed x and random y coordinate
            currentPipe++;

            if(currentPipe >= pipePoolSize) {
                currentPipe = 0; //reset to 0 once we reach pool size
            }
        }
	}
}
