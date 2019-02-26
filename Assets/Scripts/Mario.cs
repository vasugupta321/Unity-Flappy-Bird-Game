using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour {

    public float upForce = 200f;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                rb2d.velocity = Vector2.zero; //if player not dead and click mouse button then velocity is 0 making it
                                              //that player either rising or falling with exact same response every time our player flaps
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap"); // Playing animation by setting the trigger
            }
        }
	}

    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die"); // Setting the die state as we anytime we crash into something we die
        GameControl.instance.MarioDied();
    }
}
