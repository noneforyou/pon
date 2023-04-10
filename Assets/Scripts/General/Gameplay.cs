using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    // so i can pull stuff from pon script
    InitializePon initializePon;
    KnightPointsAttacks knightPointsAttacks;
    RookTarget rookTarget;
    
    // reference to gameObject of the pon scripts 
    public GameObject playerObject; 

    // original prefab
    public GameObject originalRook;
    public GameObject originalBishop;
    public GameObject originalKnight;

    void Start() {
        FindObjectOfType<ManageAudio>().PlayLoop("gridMusic"); // play game music
        if (SceneManager.GetActiveScene().name == "Level1") {
            spawnRook(0, 3);
        }
        
    }

    void Update() {
        // Debug.Log(initializePon.getPlayer());
        if (initializePon.getPlayer() != null) {
            // Debug.Log("it's working"); // yay it works
        }
    }

    // params = x coord and y coord to spawn rook
    // this is the prefab thing ur crying about little guy :D 
    void spawnRook(float x, float y) {
        Vector3 spawnLocation = new Vector3(x, y, 0);
        GameObject rook = Instantiate(originalRook, originalRook.transform);
        rook.transform.position = spawnLocation;
        
        initializePon = playerObject.GetComponent<InitializePon>();
        rookTarget = rook.GetComponent<RookTarget>();

        rookTarget.setPlayer(initializePon.getPlayer());
    }

    void spawnKnight(float x, float y) {
        Vector3 spawnLocation = new Vector3(x, y, 0);
        GameObject knight = Instantiate(originalKnight, originalKnight.transform);
        knight.transform.position = spawnLocation;

        initializePon = playerObject.GetComponent<InitializePon>();
        knightPointsAttacks = knight.GetComponent<KnightPointsAttacks>();

        knightPointsAttacks.setPlayer(initializePon.getPlayer());
    }

    void spawnBishop(float x, float y) {
        Vector3 spawnLocation = new Vector3(x, y, 0);
        GameObject bishop = Instantiate(originalBishop, originalBishop.transform);
        bishop.transform.position = spawnLocation;
    }
}

// rookTarget.setPlayer(initializePon.getPlayer());
// why is initializePon.player null it makes no sense. 
// i am at my limit.
// AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA