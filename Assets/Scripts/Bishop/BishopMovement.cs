using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopMovement : MonoBehaviour {
    public Transform origin;
    public float speed = 4f;
    public LayerMask whatStopsMovement;

    private float radius = .1f;

    private int directionX = 1;
    private int directionY = 1;

    

    void Start() {
        // ._. 
    }

    void Update() {
        Vector2 up = new Vector2(transform.position.x, transform.position.y + .4f);
        Vector2 down = new Vector2(transform.position.x, transform.position.y - .4f);

        Vector2 left = new Vector2(transform.position.x - .4f, transform.position.y);
        Vector2 right = new Vector2(transform.position.x + .4f, transform.position.y);
    
        // if on right side, bounce left, etc.
        if (Physics2D.OverlapCircle(right, radius, whatStopsMovement)) {
            directionX = -1;
            FindObjectOfType<ManageAudio>().Play("chessPiece"); // play sound (edited)
        }

        if (Physics2D.OverlapCircle(left, radius, whatStopsMovement)) {
            directionX = 1;
            FindObjectOfType<ManageAudio>().Play("chessPiece");
        }

        if (Physics2D.OverlapCircle(up, radius, whatStopsMovement)) {
            directionY = -1;
            FindObjectOfType<ManageAudio>().Play("chessPiece");
        }

        if (Physics2D.OverlapCircle(down, radius, whatStopsMovement)) {
            directionY = 1;
            FindObjectOfType<ManageAudio>().Play("chessPiece");
        }

        
        // make them bounce different directions now (annoying work)

        Vector2 target = new Vector2(transform.position.x + directionX, transform.position.y + directionY);
        transform.position = Vector2.MoveTowards(origin.position, target, speed * Time.deltaTime);
        

        // Debug.Log("Bishop Position: " + transform.position);
        // Debug.Log("Target: " + target);
    }

    void OnDrawGizmos() {
        Vector2 up = new Vector2(transform.position.x, transform.position.y + .4f);
        Vector2 down = new Vector2(transform.position.x, transform.position.y - .4f);

        Vector2 left = new Vector2(transform.position.x - .4f, transform.position.y);
        Vector2 right = new Vector2(transform.position.x + .4f, transform.position.y);

        Gizmos.DrawWireSphere(up, .1f);
        Gizmos.DrawWireSphere(down, .1f);
        Gizmos.DrawWireSphere(left, .1f);
        Gizmos.DrawWireSphere(right, .1f);
    }
}
