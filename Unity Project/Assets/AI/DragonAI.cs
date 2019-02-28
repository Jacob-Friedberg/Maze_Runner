
using UnityEngine;
using UnityEngine.AI;
public class DragonAI : MonoBehaviour
{

    private NavMeshAgent agent;
    public GameObject target;
    // Update is called once per frame

    void Start()
    {
      agent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.transform.position);
    }
}
