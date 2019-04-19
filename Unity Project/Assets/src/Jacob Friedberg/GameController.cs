using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
[RequireComponent(typeof(MazeConstructor))]

public class GameController : MonoBehaviour
{
    //Fields
    [SerializeField] private bool stress = false;

    private static MazeConstructor instance = null;


    //2
    private DateTime startTime;
    private int timeLimit;
    private int reduceLimitBy;

    private int score;
    private bool goalReached;

    //3
    public static MazeConstructor getInstance()
    {
        if(instance == null)
        {
            instance = instance.GetComponent<MazeConstructor>();
            return instance;
        }
        else
            return instance;
    }

    public void Start()
    {
        if(instance == null)
        {
            instance = GetComponent<MazeConstructor>();
            StartNewGame();
        }
        else
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
        instance.GenerateNewMaze(i, i);

    //Wait for 4 seconds
    yield return new WaitForSeconds(4);


    //Wait for 2 seconds
    yield return new WaitForSeconds(2);
            instance.GenerateNewMaze(i*i, i*i);
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
           //instance.GenerateNewMaze(13, 15, OnStartTrigger, OnGoalTrigger);

            x = instance.startCol * instance.hallWidth;
            y = 1;
            z = instance.startRow * instance.hallWidth;
        }
        else
            instance.GenerateNewMaze(13, 15);

         x =        instance.startCol *     instance.hallWidth;
         y = 1;
         z =        instance.startRow *     instance.hallWidth;
    }

    //6
    void Update()
    {

    }
}

