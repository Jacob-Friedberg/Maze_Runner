
using UnityEngine;
using UnityEngine.AI;
public class AutoMove : MonoBehaviour
{
   
    public NavMeshAgent agent;
    public GameObject dragon;
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(dragon.transform.position);
    }
}
