/* File: PlayerControl.cs
 * Author: Benjamin
 * Description: The script that manages every aspect of the player's controls
 * and the movement/actions that follow. */

using Valve.VR;
using UnityEngine;
using UnityEngine.XR;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    private const int LEFT = 0;
    private const int RIGHT = 1;

    // A boolean representing if the game is being run in VR.
    private bool isVR;
    // A boolean representing if the target is in VR.
    private bool isTargetVR;
    // A boolean representing if a controller is recieving movement input.
    private bool[] isDragging = new bool[2];

    private Vector3[] startPosition = new Vector3[2];
    private GameObject[] controller = new GameObject[2];

    // Static singleton property.
    public static AudioHandler Instance { get; private set; }

    // The scale at which the player will move based on input.
    public float moveScale = 1.25f;
    // A boolean representing if the the debug player is reset.
    public bool resetDebugPlayer;

    public SteamVR_Action_Boolean grabWorldAction;
    public SteamVR_Input_Sources[] hand = new SteamVR_Input_Sources[2];
    // The audio clip that plays when the player moves.
    public AudioClip moveClip;
    public GameObject playerTarget;
    public GameObject targetVRParent;
    public GameObject debugPlayer;
    public GameObject targetDebugParent;

    void Start()
    {
        // Debug.Log("XR Device Present: " + XRDevice.isPresent);
        // Debug.Log("XR User Presence: " + XRDevice.userPresence);
        // Debug.Log("XR Model: " + XRDevice.model);
        // Debug.Log("XR Device Active: " + XRSettings.isDeviceActive);
        // Debug.Log("XR Enabled: " + XRSettings.enabled);

        controller[LEFT] = transform.Find("SteamVRObjects").Find("LeftController").gameObject;
        controller[RIGHT] = transform.Find("SteamVRObjects").Find("RightController").gameObject;

        // Save a reference to the AudioHandler component as the singleton instance.
        Instance = this;
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
        // Runs the player death test case
        else
        {
            // playerTarget.transform.SetParent(targetDebugParent.transform);
            // playerTarget.transform.position = targetDebugParent.transform.position;

            // Automaticaly moves the debug player towards enimies to test the death sequence
            Vector3 localPosition = player.transform.position - transform.position;
            // The normalized direction in local space
            localPosition = localPosition.normalized;
            transform.Translate(localPosition.x * Time.deltaTime * speed,
                                localPosition.y * Time.deltaTime * speed,
                                localPosition.z * Time.deltaTime * speed);
        }

        if (resetDebugPlayer || isVR)
        {
            resetDebugPlayer = false;
            debugPlayer.transform.position = transform.position;
        }

        // If the right controler is not recieving any movement input...
        if (!isDragging[RIGHT])
        {
            // Process the left controller's input.
            processControllerInput(LEFT);
        }
        // If the left controler is not recieving any movement input...
        if (!isDragging[LEFT])
        {
            // Process the right controller's input.
            processControllerInput(RIGHT);
        }
    }

    void processControllerInput(int handType)
    {
        // If the player is attempting to move...
        if (grabWorldAction.GetState(hand[handType]))
        {
            if (!isDragging[handType])
            {
                isDragging[handType] = true;
                // Marks the identified controler's startting position.
                startPosition[handType] = controller[handType].transform.position;
            }

            // Creates an offset vector of the desired player's movement input.
            Vector3 offset = new Vector3(startPosition[handType].x - controller[handType].transform.position.x, 0,
                                          startPosition[handType].z - controller[handType].transform.position.z);

            // Transforms the player's position in the world.
            transform.position += (moveScale * offset);

            // Play the player movement sound effect.
            AudioHandler.Instance.PlayAudio(AudioHandler.Instance.moveClip);
        }
        else
        {
            // Mark the identified controller as not recieving input.
            isDragging[handType] = false;
        }
    }

    void OnCollisionEnter(Collider coll)
    {
        // if(gameObject.CompareTag("generated") || gameObject.CompareTag("collidable"))

        // If the player runs into a colliadable game object...
        if (coll.gameObject.name == "genderated" ||
            coll.gameObject.name == "collidable")
        {
            // Stop the player from passing through a collidable object.
            rigidbody.velocity = Vector3.zero;
        }
    }

    // Instance method, this method can be accesed through the singleton instance.
    public void PlayAudio(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
}
