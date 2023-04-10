using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // this imports math for the rounding thing
using UnityEngine.Rendering.PostProcessing;

public class RookTarget : MonoBehaviour {  
    public Animator animator; // animation stuff
    public Transform player; // player to chase
    public float aggroRange; // range to attack
    public float moveSpeed; // speed of rook
    Rigidbody2D rb2d;

    public LayerMask whatStopsMovement;
    public Transform movePoint;
    

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
    }

    public void setPlayer(Transform player) {
        this.player = player;
    }

    void Update() {
        animator.SetBool("Attacking", false);
        // chase the waypoint 
        attack();

        // this finds the distance between one point and another point!
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        
        // print("rook distance: " + distToPlayer);
        
        // if up/down
        if (player.position.x == transform.position.x && distToPlayer <= aggroRange) {
            // print("attacking!");
            findTarget();
            animator.SetBool("Attacking", true);
        } 
        
        // if left/right
        if (player.position.y == transform.position.y && distToPlayer <= aggroRange) {
            // print("attacking!");
            findTarget();
            animator.SetBool("Attacking", true);
            
            if (movePoint.position.x > transform.position.x) {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            } else {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    // moves the waypoint to the players position
    private void findTarget() {
        movePoint.position = new Vector2(player.position.x, player.position.y);
        ManageAudio bass = FindObjectOfType<ManageAudio>();
        if (!bass.isPlaying("bass")) {
            bass.Play("bass");
        }
    }

    // goes towards the waypoint
    private void attack() {
        if (transform.position.x == movePoint.position.x || transform.position.y == movePoint.position.y) { // this line is for "+" movement
            // if (transform.position.x == movePoint.position.x) {
            //     if (movePoint.position.x > transform.position.x) {
            //         gameObject.transform.localScale = new Vector3(1, 1, 1);
            //     } else {
            //         gameObject.transform.localScale = new Vector3(-1, 1, 1);
            //     }
            // }
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime); 
        }
        
    }
}
