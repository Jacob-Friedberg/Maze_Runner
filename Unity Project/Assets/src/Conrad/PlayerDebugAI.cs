
using UnityEngine;
using UnityEngine.AI;
public class PlayerDebugAI : MonoBehaviour
{
  public bool clickMode = true;

  public Camera cam;
  public NavMeshAgent agent;

  private int step = 0;
  public GameObject challice;
  public GameObject alter;

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
      switch (step) {
        case 0:
          agent.SetDestination(challice.transform.position);
          if(2 > Vector3.Distance(challice.transform.position, transform.position)){
            step++;
          }
        break;
        case 1:
          agent.SetDestination(alter.transform.position);
          if(2 > Vector3.Distance(alter.transform.position, transform.position)){
            step++;
          }
        break;
        default:
          Debug.Log("AI AUTO RUN COMPLETE");
        break;
      }
    }
  }
}
