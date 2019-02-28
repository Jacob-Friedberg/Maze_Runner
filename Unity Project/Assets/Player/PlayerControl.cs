using UnityEngine;
using UnityEngine.XR;
using System.Collections;
using Valve.VR;

public class PlayerControl : MonoBehaviour
{
  /////////////////////////////////
  private int LEFT = 0;
  private int RIGHT = 1;
  ////////////////////////////////////

  public float move_scale = 1.25f;
  public SteamVR_Action_Boolean grabWorldAction;

  private GameObject[] controller = new GameObject[2];

  // TODO Hard Code
  public SteamVR_Input_Sources[] hand = new SteamVR_Input_Sources[2];


  private bool[] isDragging = new bool[2];
  // private bool isRightDragging = false;

  private Vector3[] startPosition = new Vector3[2];
  // private Vector3 rightStartPosition;


  void Start() {
    // Debug.Log("XR Device Present: " + XRDevice.isPresent);
    // Debug.Log("XR User Presence: " + XRDevice.userPresence);
    // Debug.Log("XR Model: " + XRDevice.model);
    // Debug.Log("XR Device Active: " + XRSettings.isDeviceActive);
    // Debug.Log("XR Enabled: " + XRSettings.enabled);
    controller[LEFT] = transform.Find("SteamVRObjects").Find("LeftController").gameObject;
    controller[RIGHT] = transform.Find("SteamVRObjects").Find("RightController").gameObject;

    // hand[LEFT] = SteamVR_Input_Sources.GetSource();
  }

  void Update() {
    ProcessControllerInput(LEFT);
    ProcessControllerInput(RIGHT);
  }

  void ProcessControllerInput(int handType) {
    if (grabWorldAction.GetState(hand[handType])) {
      if(!isDragging[handType]) {
        isDragging[handType] = true;
        startPosition[handType] = controller[handType].transform.position;
      }

      Vector3 offset = new Vector3 (
        startPosition[handType].x - controller[handType].transform.position.x,
        0,
        startPosition[handType].z - controller[handType].transform.position.z
      );
      transform.position += (move_scale * offset);
    } else {
      isDragging[handType] = false;
    }
  }

}
