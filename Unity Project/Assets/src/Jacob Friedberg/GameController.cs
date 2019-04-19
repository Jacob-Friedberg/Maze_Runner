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
    
    int currentState = 0;
    int numSavedStates = 0;

    Caretaker caretaker = new Caretaker();

    Originator originator = new Originator();


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
        Undo();
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
        setState("On");
    }
}
    //begin generation of new maze.
    private void startNewMaze()
    {
        setState("On");
        float x;
        float y;
        float z;
        if(stress)
        {
            setState("off");
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
         setState("off");
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

    public void setState(string state)
    {
        originator.Set(state);
        caretaker.Add(originator.storeMem());

        numSavedStates = caretaker.GetTotalSavedStates();
        currentState = numSavedStates;
    }

    public string Undo()
    {
        if(currentState > 0)
            currentState -= 1;

        Memento prev = caretaker.Get(currentState);
        string prevState = originator.RestoreMem(prev);
        
        return prevState;
    }
    public class Memento
    {
        public string state {get; protected set;}

        public Memento(string state)
        {
            this.state = state;
        }
    }

    public class Originator
    {

        public string state;


        public void Set(string state)
        {
            print("originator: Current state is:" + state);
        }

        public Memento storeMem()
        {
            print("Originator: Storing state:" + this.state);
            return new Memento(this.state);
        }

        public string RestoreMem(Memento memento)
        {
            state = memento.state;
            print("Originator: restoring state:" + this.state);
            return state;
        }

    }

    public class Caretaker
    {
        List<Memento> savedStates = new List<Memento>();

        public void Add(Memento m)
        {
            savedStates.Add(m);
        }

        public Memento Get(int i)
        {
            return savedStates[i];
        }

        public int GetTotalSavedStates()
        {
            return savedStates.Count;
        }

    }

}

