# Maze Runner Image System
While Unity provides many features regarding image management, programmers may find that the time required for integrating this framework into an existing project to be rather tedious. This player control system is designed to be fairly portable, extensible, and easy to integrate on every level of your project.

## Movement in Unity
There are a couple of important components that the programmer needs to be aware of before starting. The HTC Vive controllers are responsible for managing the player's input and processing them in a meaningful way. Their input as movement is primarly controlled through the scripting system. Because of this, every movement-responsive game object needs code to control when and how they respond.

As will be described in the following section, this Control System simplifies some of the implementation specific details related to movement.

## General Overview
There are two primary components, the left and right controllers.

## Getting Started (controllers)
### Setting up the Controller Manager
1. Create a new empty private int called `left`
2. Create a new empty private int called `right`
3. Create a new empty private bool called `doControllerUpdate`
4. Create a public GameObject called `playerTarget`
4. Add the Controller, Left, and Right scripts

### Adding Controllers
The programmer can then add the controllers during startup.
Example:

```csharp
Controller controllerLeft = new Left();
Controller controllerRight = new Right();
left = controllerLeft.GetControllerID();
right = controllerRight.GetControllerID();
doControllerUpdate = true
```

Then during update add the following:

```csharp
playerTarget.transform.SetParent(targetVRParent.transform);
playerTarget.transform.position = targetVRParent.transform.position;
```



### Adding Player Movement
Within your local object controller script, you can move with the following code:
```csharp
processControllerInput(left);
processControllerInput(right);
```

----------------------------------------------------------
# Class Descriptions

## PlayerManager
The _PlayerManager_ is built to handle the loading of new audio resources, and provides a *static* interface for calling upon these resources. The _SoundManager_ provides the following public methods.
```csharp
processControllerInput(int handType);
void OnCollisionEnter(Collision coll);
```
### `processControllerInput(int handType)`
Processes all of the input for each controllers

### `OnCollisionEnter(Collision coll);`
Handles collisions accordingly when they occur. For example, if the player attempts to walk through a wall this function will prevent that.
