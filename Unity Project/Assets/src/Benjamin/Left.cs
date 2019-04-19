/* File: Controller.cs
 * Author: Benjamin
 * Description: The script is a demonstration of static binding for the left controller. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : Controller
{
    // When a method of a base class is overridden in a derived class, the version in the derived class is used.
    // This happens even if the calling code didn't "know" that the object was an instance of the derived class.
    // Now, if you use the new keyword instead of override, the method in the derived class does not override the method in the base class, it merely hides it.
    public override int GetControllerID()
    {
        Controller left = new Controller();

        return 0;
    }
}
