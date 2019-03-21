using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        BeginGame();
    }

    // Update is called once per frame
    private void Update()
    {
            if(Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    private void BeginGame() { }

    private void RestartGame() { }
}
