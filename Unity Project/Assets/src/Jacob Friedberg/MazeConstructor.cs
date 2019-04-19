using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeConstructor : MonoBehaviour
{
    //Fields
    [SerializeField] private Material mazeMat1;
    [SerializeField] private Material mazeMat2;

    //public variables
    public bool showDebug;
    
    //private variables
    private MazeDataGenerator dataGenerator;
    private MazeMeshGenerator meshGenerator;

    //Getters and setters.
    public int[,] data
    {
        get; private set;
    }

    public float hallWidth
    {
        get; private set;
    }
    public float hallHeight
    {
        get; private set;
    }

    public int startRow
    {
        get; private set;
    }
    public int startCol
    {
        get; private set;
    }

    public int goalRow
    {
        get; private set;
    }
    public int goalCol
    {
        get; private set;
    }

    void Awake()
    {
        dataGenerator = new MazeDataGenerator();
        meshGenerator = new MazeMeshGenerator();
        data = new int[,]
        {
            { 1,1,1 },
            { 1,0,1 },
            { 1,1,1 }
        };
    }

    public void DisposeOldMaze()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Generated");
        foreach (GameObject go in objects)
        {
            Destroy(go);
        }
    }

    public void GenerateNewMaze(int sizeRows, int sizeCols)
    {
        if (sizeRows % 2 == 0 && sizeCols % 2 == 0)
        {
            Debug.LogError("Odd numbers work better for dungeon size.");
        }

        DisposeOldMaze();

        data = dataGenerator.FromDimensions(sizeRows, sizeCols);

        // store values used to generate this mesh
        hallWidth = meshGenerator.width;
        hallHeight = meshGenerator.length;

        DisplayMaze();
    }

    //Debug display of Maze
    private void OnGUI()
    {
        if (!showDebug)
        {
            return;
        }


        int[,] maze = data;
        int rowMax = maze.GetUpperBound(0);
        int colMax = maze.GetUpperBound(1);

        string msg = "";
        //print out maze debug
        for (int i = rowMax; i >= 0; i--)
        {
            for (int j = 0; j <= colMax; j++)
            {
                if (maze[i, j] == 0)
                {
                    msg += "....";
                }
                else
                {
                    msg += "==";
                }
            }
            msg += "\n";
        }
        GUI.Label(new Rect(200, 200, 500, 500), msg);
    }

    //displays the generated maze in 3D space and applies materials
    private void DisplayMaze()
    {
        GameObject go = new GameObject();

        go.transform.position = Vector3.zero;
        go.name = "Procedural Maze";
        go.tag = "Generated";

        MeshFilter mf = go.AddComponent<MeshFilter>();
        mf.mesh = meshGenerator.FromData(data);

        MeshCollider mc = go.AddComponent<MeshCollider>();
        mc.sharedMesh = mf.mesh;

        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        mr.materials = new Material[2] { mazeMat1, mazeMat2 };
    }
}
  