/* File: Controller.cs
 * Author: Benjamin
 * Description: The script is a demonstration of static binding for the right controller. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : Controller
{
    public override int GetControllerID()
    {
        Controller right = new Controller();

        return 1;
    }
}
