
/*  AutoMove.cs
    Corbin Schueller
    This scirpt controls the default movement of the dragons */
    
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
