using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    bool gameOver = false;
    public float restartDelay = 1f;
    public float levelChangeDelay = 0;
    public int currentLevel = 1;
    public void EndGame() {
        if (gameOver == false) {
            gameOver = true;
            Debug.Log("restart");
            Invoke("Restart", restartDelay); 
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("next level");
            Invoke("nextLevel", levelChangeDelay);
            
        }
    }

    private void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reloads the current scene
    }

    private void nextLevel() {
        currentLevel++;
        SceneManager.LoadScene("Level" + currentLevel);
    }
}
