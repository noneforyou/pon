using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeCamera : MonoBehaviour {
    public float width = 1;
    public float height = 1;
    public Transform player;
    
    void Awake() {
        // set the scaling
        Vector3 scale = new Vector3( width, height, 1f );
        transform.localScale = scale;
    }

    void Update() {
        // Vector3 position = new Vector3( player.transform.position.x, player.transform.position.y, -5);
        Vector3 position = new Vector3( 0, 0, -5);
        transform.position = position;
    }
}
