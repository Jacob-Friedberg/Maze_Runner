using UnityEngine;
using System.Collections;
using Valve.VR;

public class DragControl : MonoBehaviour
{
  public SteamVR_Input_Sources handType;
  public SteamVR_Action_Boolean grabWorldAction;

  private bool start_drag = false;

  public float move_scale = 1.25f;

  private Vector3 start_position;

  public GameObject controller;

  void Start() {
  }

  void Update() {
    if (grabWorldAction.GetState(handType)) {
      if(!start_drag) {
        start_drag = true;
        start_position = controller.transform.position;
      }

      //transform.position.x

      Vector3 offset = new Vector3 (
        start_position.x - controller.transform.position.x,
        0,
        start_position.z - controller.transform.position.z
      );

      // player.transform.position += (move_scale * offset);
      transform.position += (move_scale * offset);
    } else {
      if(start_drag){
        start_drag = false;
      }
    }
  }
}
