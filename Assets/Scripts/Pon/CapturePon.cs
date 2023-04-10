using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePon : MonoBehaviour
{
    // public InitializePon pon;
    // private void OnCollisionEnter2D(Collision2D collision) {
    //     if (collision.gameObject.tag == "Player") {
    //         pon.slaughterPon();
    //     }
    // }

    public KnightPointsAttacks knight;
    public Transform knightPos;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            FindObjectOfType<ManageAudio>().Play("deathSound"); // play sound 
            slaughterPon();
        }
        
    }

    public void slaughterPon() {
        Destroy(gameObject);
        FindObjectOfType<LevelSystem>().EndGame();
        // Debug.Log("pon has been killed");
    }
}
