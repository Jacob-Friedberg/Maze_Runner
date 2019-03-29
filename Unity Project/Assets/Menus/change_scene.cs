using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene : MonoBehaviour
{
    public void PlayMazeRunner()
    {
        SceneManager.LoadScene("maze_game");
    }
}
