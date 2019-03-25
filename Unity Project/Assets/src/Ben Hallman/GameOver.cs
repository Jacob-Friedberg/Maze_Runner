using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("DeathTrigger"))
        {
            Debug.Log("PLAYER DEATH");
        }
    }
}