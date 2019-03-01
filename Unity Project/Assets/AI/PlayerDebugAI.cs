
using UnityEngine;
using UnityEngine.AI;
public class PlayerDebugAI : MonoBehaviour
{
  public bool clickMode = true;

  public Camera cam;
  public NavMeshAgent agent;
  // Update is called once per frame
  void Update()
  {
    if (clickMode) {
      if (Input.GetMouseButtonDown(0)){
      Ray ray = cam.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      if(Physics.Raycast(ray, out hit)){
        // MOVE AGENT
        agent.SetDestination(hit.point);
      }

      }
    } else {
      //Automode
    }
  }
}
