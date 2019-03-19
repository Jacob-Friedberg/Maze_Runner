using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
[RequireComponent(typeof(MazeConstructor))]

public class GameController : MonoBehaviour
{
    //1W
    [SerializeField] private FpsMovement player;
    [SerializeField] private bool stress;
    [SerializeField] private Text timeLabel;
    [SerializeField] private Text scoreLabel;

    private MazeConstructor generator;

    //2
    private DateTime startTime;
    private int timeLimit;
    private int reduceLimitBy;

    private int score;
    private bool goalReached;

    //3
    public void Start()
    {
        generator = GetComponent<MazeConstructor>();
        StartNewGame();
    }

    //4
    private void StartNewGame()
    {
       
        StartNewMaze();
    }

    //5

IEnumerator waiter(int i)
{
    generator.GenerateNewMaze(i, i, OnStartTrigger, OnGoalTrigger);

    //Wait for 4 seconds
    yield return new WaitForSeconds(4);

   
    //Wait for 2 seconds
    yield return new WaitForSeconds(2);
     generator.GenerateNewMaze(i*i, i*i, OnStartTrigger, OnGoalTrigger);
}

    private void StartNewMaze()
    {
        float x;
        float y;
        float z;
        if(stress)
        {
            for (int i = 1; i < 10; i*=3)
            {
                StartCoroutine(waiter(i));
            }
           // generator.GenerateNewMaze(13, 15, OnStartTrigger, OnGoalTrigger);
            
            x = generator.startCol * generator.hallWidth;
            y = 1;
            z = generator.startRow * generator.hallWidth;
            player.transform.position = new Vector3(x, y, z);
           

            goalReached = false;
            player.enabled = true;

            // restart timer
            timeLimit -= reduceLimitBy;
            startTime = DateTime.Now;
        }
        else
        generator.GenerateNewMaze(13, 15, OnStartTrigger, OnGoalTrigger);

         x = generator.startCol * generator.hallWidth;
         y = 1;
         z = generator.startRow * generator.hallWidth;
        player.transform.position = new Vector3(x, y, z);

        goalReached = false;
        player.enabled = true;

        // restart timer
        timeLimit -= reduceLimitBy;
        startTime = DateTime.Now;
    }

    //6
    void Update()
    {
        if (!player.enabled)
        {
            return;
        }

        int timeUsed = (int)(DateTime.Now - startTime).TotalSeconds;
        int timeLeft = timeLimit - timeUsed;

        if (timeLeft > 0)
        {
            timeLabel.text = timeLeft.ToString();
        }
        else
        {
            timeLabel.text = "TIME UP";
            player.enabled = false;

            Invoke("StartNewGame", 4);
        }
    }

    //7
    private void OnGoalTrigger(GameObject trigger, GameObject other)
    {
        Debug.Log("Goal!");
        goalReached = true;

        score += 1;
        scoreLabel.text = score.ToString();

        Destroy(trigger);
    }

    private void OnStartTrigger(GameObject trigger, GameObject other)
    {
        if (goalReached)
        {
            Debug.Log("Finish!");
            player.enabled = false;

            Invoke("StartNewMaze", 4);
        }
    }
}

