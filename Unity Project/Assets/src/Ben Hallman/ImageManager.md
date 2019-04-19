# Maze Runner Image System
While Unity provides many features regarding image management, programmers may find that the time required for integrating this framework into an existing project to be rather tedious. This image system is designed to be fairly portable, extensible, and easy to integrate on every level of your project.

## Colors in Unity
There are a couple of important components that the programmer needs to be aware of before starting.

As will be described in the following section, this Image System simplifies some of the implementation specific details related to movement.

## General Overview
There are two primary components, the left and right controllers.

## Getting Started
### Setting up the Controller Manager
1. Create a new empty public Image called `imageName`
2. Create a new empty private float called `valf`
3. Add the following: `ColorManager colormanager = new ColorManager()`
4. Add the following: `UnityEngine`, `using UnityEngine.UI`, `System.Collections`, and `System.Collections.Generic`.

### Adding Colors
The programmer can then add colors during startup.
Example:

```csharp
// Initialize with standard colors
colormanager["red"] = new Colors(255, 0, 0);
colormanager["green"] = new Colors(0, 255, 0);
colormanager["blue"] = new Colors(0, 0, 255);
colormanager["black"] = new Colors(0, 0, 0);
colormanager["white"] = new Colors(255, 255, 255);

// Clones selected colors
Colors red = colormanager["red"].Clone() as Colors;
Colors black = colormanager["black"].Clone() as Colors;
```

----------------------------------------------------------
# Class Descriptions

## Image Handler
The _ImageHandler_ is built to handle the loading of new images and colors, and provides a *static* interface for calling upon these resources. The _ImageHandler_ provides the following public methods.
```csharp
Colors(int red, int green, int blue);
```

### `Colors(int red, int green, int blue);`
This is the Colors constructor.
