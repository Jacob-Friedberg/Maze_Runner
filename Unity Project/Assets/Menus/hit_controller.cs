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
      //Start menu to world 1
        if(col.gameObject.CompareTag("StartWorld"))
        {
            SceneManager.LoadScene("world1");
            player.transform.position = new Vector3(-103, 0, -43);
        }

        if(col.gameObject.CompareTag("MazeToWorld"))
        {
            SceneManager.LoadScene("Proc_gen");
            player.transform.position = new Vector3(3.75f, 0.5f, 3.75f);
        }

        if(col.gameObject.CompareTag("ToMazeExit"))
        {
            SceneManager.LoadScene("world1");
            player.transform.position = new Vector3(12, 0, -307);
        }

        if(col.gameObject.CompareTag("MazeToCastle"))
        {
            SceneManager.LoadScene("Proc_gen");
            player.transform.position = new Vector3(48.75f, 0.5f, 41.75f);
        }

        if(col.gameObject.CompareTag("ToMazeEntrance"))
        {
            SceneManager.LoadScene("world1");
            player.transform.position = new Vector3(87, 0, -43);
        }

    }
}
