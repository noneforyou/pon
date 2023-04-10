using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePon : MonoBehaviour {
    public float width = 1;
    public float height = 1;
    public Vector3 position = new Vector3( 0, -2, 0 );
    public Transform player; // self
    
    void Awake() {
        // set the scaling
        Vector3 scale = new Vector3( width, height, 1f );
        transform.localScale = scale;
        // set the position
        transform.position = position;
    }

    public Transform getPlayer() {
        return player;
    }
}