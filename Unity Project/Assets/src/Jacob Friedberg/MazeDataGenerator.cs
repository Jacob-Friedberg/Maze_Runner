using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDataGenerator
{
    public float placementThreshold;

    //threshold of valid space is availible.
    public MazeDataGenerator()
    {
        placementThreshold = .1f;                               // 1
    }

    //generate a 2d maze from dimensions given
    public int[,] FromDimensions(int rowSize, int colSize)    // 2
    {
        int[,] maze = new int[rowSize, colSize];
        
        //set up maxes
        int rowMax = maze.GetUpperBound(0);
        int colMax = maze.GetUpperBound(1);

        //algorithm to assign walls to exteriror and every other cell at random.
        for (int i = 0; i <= rowMax; i++)
        {
            for (int j = 0; j <= colMax; j++)
            {
                // sets up walls on the exterior
                if(i == 0 || j == 0 || i == rowMax || j == colMax)
                {
                    maze[i, j] = 1;
                }
                //opperate on every other cell of the 2d array
                else if (i % 2 == 0 && j % 2 == 0)
                {
                    if(Random.value > placementThreshold)
                    {
                        //assigns a 1 to current cell
                        maze[i, j] = 1;
                        //ternary operations
                        int a = Random.value < .5 ? 0 : (Random.value < .5 ? -1 : 1);
                        //ternary operations
                        int b = a != 0 ? 0 : (Random.value < .5 ? -1 : 1);
                        // assigns 1 to a randomly chosen cell around the current index
                        maze[i + a, j + b] = 1;

                    }
                }
            }
        }
        return maze;
    }
}
