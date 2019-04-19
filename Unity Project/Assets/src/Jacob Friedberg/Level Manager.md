# Maze Runner Level systems
While Unity provides many features regarding designing levels, with simple drag and drop interfaces within the application. To get procedurally generated mazes requires the use of the Maze Generation files I have created for this specific purpose 

## General Overview
Maze generation with this library will allow you to create mazes of varying sizes, and with different materials adorning the floors, ceilings, and walls. These mazes are guranteed to be different every single time. 
However it is important to note that this Maze will be based at the Vector3d(0,0,0) within your world. So it is best left as a seperate scene.

## Getting Started
### Setting up the Maze generator
1. Create an empty scene for the Maze to be generated in.
2. Create an empty object within the scene that will control the mazes construction.
3. Attach both the Game controller and Maze Constructor scripts to this object. Ensure that stress is not checked in the inspector.
4. Within the Maze Constructer script in the inspector add whatever materials that you wish.
5. You are now done and the Maze will be generated when the scene is run.

### Generating a maze from a different script than Game Controller.
To generate a maze from another file than what is included, simply add the following code snippets to you code.
Example:
```csharp
[RequireComponent(typeof(MazeConstructor))]
MazeConstructor mazeConstructer = new MazeConstructor();

mazeConstructor = mazeConstructor.getInstance();

mazeConstructor.startNewGame();

```
----------------------------------------------------------
# Class Descriptions

## MazeConstructor
The _MazeConstructor_ provides the following public methods.

```csharp
public static MazeConstructor getInstance();
public void Start();
```
### `public static MazeConstructor getInstance()`
Allows access to the single instance of the MazeConstructor via other classes

### ` public void Start();`
Handles all setup of the maze and its generation

----------------------------------------------------------
# Full Code

```csharp
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

    //what a state is
    public class Memento
    {
        public string state {get; protected set;}

        public Memento(string state)
        {
            this.state = state;
        }
    }

    //setter/restor/store of states
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
    //contains list of states.
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

```
