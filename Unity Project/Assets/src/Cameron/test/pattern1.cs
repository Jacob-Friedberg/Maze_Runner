using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// create a Singleton class
class Singleton
{
    private static Singleton _instance;

    // protected constructor
    protected Singleton()
    {
    }

    public static Singleton Instance()
    {
        // if there is no instance of a singleton then create one
        if(_instance == null)
        {
            _instance = new Singleton();
        }

        // return the single instance of the Singleton
        return _instance;
    }
}
