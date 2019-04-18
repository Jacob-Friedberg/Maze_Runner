using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

public class Cubes
{
    virtual public void complain()
    {
        Debug.Log("I am here to complain about requirements");
    }
}


//    virtual public void changeColor(Color newColor)
//    {
//        Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
//            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
//            {
//                renderers[rendererIndex].material.color = newColor;
//            }
//    }
