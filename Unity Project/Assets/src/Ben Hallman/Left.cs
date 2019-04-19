/* File: Controller.cs
 * Author: Benjamin
 * Description: The script is a demonstration of static binding for the left controller. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : Controller
{
    public override int GetControllerID()
    {
        Controller left = new Controller();

        return 0;
    }
}
