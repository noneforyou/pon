using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightPointsAttacks : MonoBehaviour
{
    public Transform pon;

    void Update() {
        // Debug.Log("knight at " + transform.position + " : " + pon.position);     this code proved that the knights had pon's correct position
        // why isn't this working? 
        if (pon.transform.position.x > transform.position.x) {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        } else {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void setPlayer(Transform player) {
        this.pon = player;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            transform.position = pon.position;
        }
    }
}