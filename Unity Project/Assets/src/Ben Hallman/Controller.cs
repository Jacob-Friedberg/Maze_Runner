/* File: Controller.cs
 * Author: Benjamin
 * Description: The script is a demonstration of dynamic binding for a controller. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    // The virtual keyword is used to modify a method, property, indexer or event declaration, and allow it to be overridden in a derived class.
    // This is all to do with polymorphism.
    // When a virtual method is called on a reference, the actual type of the object that the reference refers to is used to decide which method implementation to use.
    public virtual int GetControllerID()
    {
        return -1;
    }
}
