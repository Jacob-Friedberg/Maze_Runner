# Maze Runner Player System
While Unity provides many features regarding player and character management, programmers may find that the time required for integrating this framework into an existing project to be rather tedious. This sound system is designed to be fairly portable, extensible, and easy to integrate on every level of your project.

## Movement in Unity
There are a couple of important components that the programmer needs to be aware of before starting. In Unity, there are a minimum of 3 objects needed for sound. An AudioListener, an AudioSource, and an AudioClip. The idea is that anything that needs to emit sound has an AudioSource component attached to it. The AudioSource is responsible for playing one sound at a time, and is primarly controlled through the scripting system. Because of this, every audio-responsive game object needs code to control when and how they emit sound.

Another important condition to note is that Unity only permits *one AudioListener at a time* to exist in the scene. We recommend that this AudioListener be attached to your player object, but we haven't seen any specific reason not to.

As will be described in the following section, this Sound System simplifies some of the implementation specific details related to sound.

## General Overview
There are two primary components (and one example extension) included. The _SoundManager_, and the _CSound_ classes. You may also find the _CMusic_ class, which serves as an extension to _CSound_.

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
Make sure that the object about to play sound has an `AudioSource` attached to it. Within your local object controller script, you can play added sounds with the following code:
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
