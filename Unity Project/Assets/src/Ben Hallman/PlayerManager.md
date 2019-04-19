# Maze Runner Player System
While Unity provides many features regarding player and character management, programmers may find that the time required for integrating this framework into an existing project to be rather tedious. This player control system is designed to be fairly portable, extensible, and easy to integrate on every level of your project.

## Movement in Unity
There are a couple of important components that the programmer needs to be aware of before starting. The HTC Vive controllers are responsible for managing the player's input and processing them in a meaningful way. Their input as movement is primarly controlled through the scripting system. Because of this, every movement-responsive game object needs code to control when and how they respond.

As will be described in the following section, this control system simplifies some of the implementation specific details related to movement.

## General Overview
There are two primary components, the left and right controllers.

## Getting Started
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
The _PlayerManager_ provides the following public methods.

```csharp
processControllerInput(int handType);
void OnCollisionEnter(Collision coll);
```
### `processControllerInput(int handType)`
Processes all of the input for each controllers

### `OnCollisionEnter(Collision coll);`
Handles collisions accordingly when they occur. For example, if the player attempts to walk through a wall this function will prevent that.

----------------------------------------------------------
# Full Code

```csharp
using Valve.VR;
using UnityEngine;
using UnityEngine.XR;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    private int left;
    private int right;

    // A boolean representing if the game is being run in VR.
    private bool isVR;
    // A boolean representing if the target is in VR.
    private bool isTargetVR;
    private bool doControllerUpdate;
    // A boolean representing if a controller is recieving movement input.
    private bool[] isDragging = new bool[2];

    private Vector3[] startPosition = new Vector3[2];
    private GameObject[] controller = new GameObject[2];

    // The scale at which the player will move based on input.
    public float moveScale = 1.25f;
    // A boolean representing if the the debug player is reset.
    public bool resetDebugPlayer;

    public SteamVR_Action_Boolean grabWorldAction;
    public SteamVR_Input_Sources[] hand = new SteamVR_Input_Sources[2];
    public GameObject playerTarget;
    public GameObject targetVRParent;
    public GameObject debugPlayer;
    public GameObject targetDebugParent;

    AudioSource source;

    public void Lock()
    {
        doControllerUpdate = false;
    }
    public void Unlock()
    {
        doControllerUpdate = true;
    }

    void Start()
    {
        // Ussage of static and dynamic binding.
        Controller controllerLeft = new Left();
        Controller controllerRight = new Right();
        left = controllerLeft.GetControllerID();
        right = controllerRight.GetControllerID();

        // Debug.Log("XR Device Present: " + XRDevice.isPresent);
        // Debug.Log("XR User Presence: " + XRDevice.userPresence);
        // Debug.Log("XR Model: " + XRDevice.model);
        // Debug.Log("XR Device Active: " + XRSettings.isDeviceActive);
        // Debug.Log("XR Enabled: " + XRSettings.enabled);

        doControllerUpdate = true;

        source = GetComponent<AudioSource>();

        controller[left] = transform.Find("SteamVRObjects").Find("LeftController").gameObject;
        controller[right] = transform.Find("SteamVRObjects").Find("RightController").gameObject;

        // Adds the player movement sound.
        SoundManager.Instance.AddSoundFromFile("movement", "Attack Jump & Hit Damage Human Sounds/Jump & Attack 9");
    }

    void Update()
    {
        isVR = transform.Find("SteamVRObjects").gameObject.activeSelf;

        // If the game is being run and VR is functional, run the game as such...
        if (isVR)
        {
            playerTarget.transform.SetParent(targetVRParent.transform);
            playerTarget.transform.position = targetVRParent.transform.position;
        }
        // Runs the player death test case.
        else
        {
            // playerTarget.transform.SetParent(targetDebugParent.transform);
            // playerTarget.transform.position = targetDebugParent.transform.position;

            // Automaticaly moves the debug player towards enimies to test the death sequence.
            // The bound of success for this test is the player takes damage and dies.
            // The bound of failer for this is the player does not die.
            // This test also tests randomized collisions on walls and the test also fails if collisions fail to work.
            Vector3 localPosition = targetDebugParent.transform.position - transform.position;
            // The normalized direction in local space.
            localPosition = localPosition.normalized;
            transform.Translate(localPosition.x * Time.deltaTime * moveScale,
                                localPosition.y * Time.deltaTime * moveScale,
                                localPosition.z * Time.deltaTime * moveScale);
        }

        if (resetDebugPlayer || isVR)
        {
            resetDebugPlayer = false;
            debugPlayer.transform.position = transform.position;
        }

        // If the right controler is not recieving any movement input...
        if (!isDragging[right])
        {
            // Process the left controller's input.
            processControllerInput(left);
        }
        // If the left controler is not recieving any movement input...
        if (!isDragging[left])
        {
            // Process the right controller's input.
            processControllerInput(right);
        }

        Unlock();
    }

    void processControllerInput(int handType)
    {
        // If the player is attempting to move...
        if (doControllerUpdate)
        {
            if (grabWorldAction.GetState(hand[handType]))
            {
                if (!isDragging[handType])
                {
                    isDragging[handType] = true;
                    startPosition[handType] = controller[handType].transform.position;
                }

                // Plays the player movement sound effect.
                SoundManager.Instance.Play(source, "movement");

                Vector3 offset = new Vector3(startPosition[handType].x - controller[handType].transform.position.x,
                              0, startPosition[handType].z - controller[handType].transform.position.z);
                transform.position += (moveScale * offset);
            }
            else
            {
                // Mark the identified controller as not recieving input.
                isDragging[handType] = false;
            }
        }

        void OnCollisionEnter(Collision coll)
        {
            // if(gameObject.CompareTag("generated") || gameObject.CompareTag("collidable"))

            // If the player runs into a colliadable game object...
            if (coll.gameObject.name == "genderated" ||
                coll.gameObject.name == "collidable")
            {
                // Stop the player from passing through a collidable object.
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}
```
