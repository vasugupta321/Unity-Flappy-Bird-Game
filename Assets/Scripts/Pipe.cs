﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Mario> () != null)
        {
            GameControl.instance.MarioScored();
        }
    }
}
