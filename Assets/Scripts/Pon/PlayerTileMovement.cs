using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileMovement : MonoBehaviour {
    public Animator animator;
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;

    // Start is called before the first frame update
    void Start() {
        movePoint.parent = null; 
    }

    // Update is called once per frame
    void Update() {
        // transform is the coord thingy, so set that to 
        // vector movetowards command basically just teleports whatever the first param is
        // to the second param, with the movespeed
        // so deadass just, "move from p1 to p2" (character to movepoint)
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        // to make it tile based, make the player only allowed to move when on the tile point which basically 
        // confirms that your player isn't moving anymore
    


        if (Vector3.Distance(transform.position, movePoint.position) <= 0.0) { // can do .05f for leeway btw feels less clunky than 0
            animator.SetFloat("speed", 0);
            // this code prevents diagonal movement
            float movementX = Input.GetAxisRaw("Horizontal");
            float movementY = Input.GetAxisRaw("Vertical");
            
            if (Mathf.Abs(movementY) >= Mathf.Abs(movementX)) {
                movementX = 0;
            }
            else {
                movementY = 0;
            }
            // it prevents diagonal movement by making it so if 2 things pressed at the same time they cancel out one of the movements 
            // its not equal to because controllers aren't binary they can have float values 


            if (Mathf.Abs(movementX) == 1f) {
                // "if there's no object in front of us, move forward"
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement)) {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    animator.SetFloat("speed", 1); // sets animation to movement
                    FindObjectOfType<ManageAudio>().Play("moveSound"); // play movement sound

                }
            } 

            if (Mathf.Abs(movementY) == 1f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement)) {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    animator.SetFloat("speed", 1); // sets animation to movement
                    FindObjectOfType<ManageAudio>().Play("moveSound"); // play movement sound

                }
            } 
        }
    }
}
