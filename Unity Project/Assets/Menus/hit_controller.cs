using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hit_controller : MonoBehaviour
{
    GameObject player;
    void Start()
    {
      player = transform.parent.parent.gameObject;
    }

    // Watch for the player to interact with the play button
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("StartWorld"))
        {
            SceneManager.LoadScene("maze_game");
            player.transform.position = new Vector3(0,0,0);
        }
    }
}
