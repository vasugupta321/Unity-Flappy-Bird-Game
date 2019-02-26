using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

	// Use this for initialization
	void Start () {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
        }
	}

    private void RepositionBackground() //function to reposition background when its time to move it
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0); //double length of collider and jump object passed one that is visable 
                                                                            //into to new position in front to be ready to scroll into view
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
