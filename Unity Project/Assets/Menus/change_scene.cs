using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene : MonoBehaviour
{
    // Swap the scene to the main game when this function is called
    public void PlayMazeRunner()
    {
        SceneManager.LoadScene("maze_game");
    }

    // Watch for the player to interact with the play button
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("SwapScene"))
        {
            PlayMazeRunner();
        }
    }
}
