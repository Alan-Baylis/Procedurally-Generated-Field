using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    public KeyCode startKey = KeyCode.Space; // Button to press that restarts the level.
    public Maze mazePrefab; 
    private Maze mazeInstance;
    
    private void Start() {
        BeginGame();
    }
    
    private void Update() {
        if (Input.GetKey(startKey)) {
            RestartGame();
        }
    }
    
    private void BeginGame() {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Generate();
    }
    
    private void RestartGame() {
        // Destroy the maze instance and restart the generation
        Destroy(mazeInstance.gameObject);
        BeginGame();
    }
}
