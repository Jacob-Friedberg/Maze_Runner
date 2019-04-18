using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitController : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("StartWorld"))
        {
            // player.GetComponent<PlayerControl>().Lock();
            player.transform.position = new Vector3(-103, 0, -43);
            SceneManager.LoadScene("world1");
        }

        if(col.gameObject.CompareTag("MazeToWorld"))
        {
            // player.GetComponent<PlayerControl>().Lock();
            player.transform.position = new Vector3(3.75f, 0.5f, 3.75f);
            SceneManager.LoadScene("Proc_gen");
        }

        if(col.gameObject.CompareTag("ToMazeExit"))
        {
            // player.GetComponent<PlayerControl>().Lock();
            player.transform.position = new Vector3(12, 0, -307);
            SceneManager.LoadScene("world1");
        }

        if(col.gameObject.CompareTag("MazeToCastle"))
        {
            // player.GetComponent<PlayerControl>().Lock();
            player.transform.position = new Vector3(48.75f, 0.5f, 41.75f);
            SceneManager.LoadScene("Proc_gen");
        }

        if(col.gameObject.CompareTag("ToMazeEntrance"))
        {
            // player.GetComponent<PlayerControl>().Lock();
            player.transform.position = new Vector3(87, 0, -43);
            SceneManager.LoadScene("world1");
        }

    }
}
