using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Required : MonoBehaviour
{
    public void OneLineWonder()
    {
        Cubes cubyBoi = new OtherCube();
        Debug.Log(cubyBoi.complain());
    }

    public void OneLineWander()
    {
        Cubes cubyBoi = new Cubes();
        Debug.Log(cubyBoi.complain());
    }
}
