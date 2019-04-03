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

    public float moveScale = 1.25f;
    public SteamVR_Action_Boolean grabWorldAction;
    public SteamVR_Input_Sources[] hand = new SteamVR_Input_Sources[2];

    public bool resetDebugPlayer;
    public GameObject debugPlayer;

    private GameObject[] controller = new GameObject[2];
    private bool[] isDragging = new bool[2];
    private Vector3[] startPosition = new Vector3[2];
    private bool isVR;
    private bool isTargetVR;

    public GameObject playerTarget;
    public GameObject targetVRParent;
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
    }

    void Update()
    {
        isVR = transform.Find("SteamVRObjects").gameObject.activeSelf;

        if (isVR)
        {
            playerTarget.transform.SetParent(targetVRParent.transform);
            playerTarget.transform.position = targetVRParent.transform.position;
        }
        else
        {
            playerTarget.transform.SetParent(targetDebugParent.transform);
            playerTarget.transform.position = targetDebugParent.transform.position;
        }

        if (resetDebugPlayer || isVR)
        {
            resetDebugPlayer = false;
            debugPlayer.transform.position = transform.position;
        }

        if (!isDragging[RIGHT])
        {
            processControllerInput(LEFT);
        }

        if (!isDragging[LEFT])
        {
            processControllerInput(RIGHT);
        }
    }

    void processControllerInput(int handType)
    {

        if (grabWorldAction.GetState(hand[handType]))
        {
            if (!isDragging[handType])
            {
                isDragging[handType] = true;
                startPosition[handType] = controller[handType].transform.position;
            }

            Vector3 offset = new Vector3(startPosition[handType].x - controller[handType].transform.position.x, 0,
                                          startPosition[handType].z - controller[handType].transform.position.z);

            transform.position += (moveScale * offset);
        }
        else
        {
            isDragging[handType] = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // if(gameObject.CompareTag("generated") || gameObject.CompareTag("collidable"))
        if (collision.gameObject.name == "genderated" ||
            collision.gameObject.name == "collidable")
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
}
