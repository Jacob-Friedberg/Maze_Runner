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

    //Private singleton
    private static MazeConstructor instance = null;


    //Public variables
    public float avgFrameRate;
    public float deltaTime = 0.0f;
    public int maxMazeSize;



    //Singleton GetInstance
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

    //Runs on begin of scene.
    public void Start()
    {
        //Construct singleton
        if(instance == null)
        {
            instance = GetComponent<MazeConstructor>();
            startNewGame();
        }
        //Singleton already exists
        else
            startNewGame();
    }

    //Begin construction of maze
    private void startNewGame()
    {
        startNewMaze();
    }

//Pause loop for stress testing.
IEnumerator waiter()
{
    //generate bigger and bigger mazes until <30fps i reached
    for(int i = 3; i < 300; i+=2)
    {
        maxMazeSize = i;
        print("Size:" + i);
        instance.GenerateNewMaze(i, i);
        yield return new WaitForSeconds(1);

            if(avgFrameRate < 30.0)
            {
                print("max playable maze:" + maxMazeSize);
                Debug.Break();
            }
        instance.DisposeOldMaze();
        yield return new WaitForSeconds(1);
    }
}
    //begin generation of new maze.
    private void startNewMaze()
    {
        float x;
        float y;
        float z;
        if(stress)
        {
            StartCoroutine(waiter());

            x = instance.startCol * instance.hallWidth;
            y = 1;
            z = instance.startRow * instance.hallWidth;
        }
        else
            instance.GenerateNewMaze(13, 15);

         x = instance.startCol * instance.hallWidth;
         y = 1;
         z = instance.startRow * instance.hallWidth;
    }

    //Update is called every frame, if the MonoBehaviour is enabled.
    void Update()
    {
        //generate an Fps number
        if(stress)
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            avgFrameRate = 1.0f / deltaTime;
            print("fps:" + avgFrameRate);
        }
        
    }
}

