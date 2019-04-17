using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hit_controller : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
      // player = transform.parent.parent.parent.gameObject
    }



    // Watch for the player to interact with the play button
    void OnTriggerEnter(Collider col)
    {
      //Start menu to world 1
        if(col.gameObject.CompareTag("StartWorld"))
        {
            player.GetComponent<PlayerControl>().Lock();
            player.transform.position = new Vector3(-103, 0, -43);
            SceneManager.LoadScene("world1");
        }

        if(col.gameObject.CompareTag("MazeToWorld"))
        {
            player.GetComponent<PlayerControl>().Lock();
            player.transform.position = new Vector3(3.75f, 0.5f, 3.75f);
            SceneManager.LoadScene("Proc_gen");
        }

        if(col.gameObject.CompareTag("ToMazeExit"))
        {
            player.GetComponent<PlayerControl>().Lock();
            player.transform.position = new Vector3(12, 0, -307);
            SceneManager.LoadScene("world1");
        }

        if(col.gameObject.CompareTag("MazeToCastle"))
        {
            player.GetComponent<PlayerControl>().Lock();
            player.transform.position = new Vector3(48.75f, 0.5f, 41.75f);
            SceneManager.LoadScene("Proc_gen");
        }

        if(col.gameObject.CompareTag("ToMazeEntrance"))
        {
            player.GetComponent<PlayerControl>().Lock();
            player.transform.position = new Vector3(87, 0, -43);
            SceneManager.LoadScene("world1");
        }

        // teleportation test instance
        if(col.gameObject.CompareTag("teletest"))
        {
            player.GetComponent<PlayerControl>().Lock();
            player.transform.position = new Vector3(4.7f, 1, -3.4f);
            player.GetComponent<PlayerControl>().moveScale += 0.3f;
        }

    }
}
