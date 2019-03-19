
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class DragonAI : MonoBehaviour
{

  private NavMeshAgent agent;
  private bool isAttacking = false;
  private bool isDead = false;
  private float attackDistance;

  public GameObject attackTrigger;
  public GameObject target;

  void Start()
  {
    agent = this.GetComponent<NavMeshAgent>();
    attackDistance = attackTrigger.transform.localScale.magnitude;
    Debug.Log(attackDistance);
  }

  void Update()
  {
    if (false == isAttacking && false == isDead) {
      agent.SetDestination(target.transform.position);

      if (Vector3.Distance(attackTrigger.transform.position, target.transform.position) < attackDistance) {
        GetComponent<Animator>().Play("Atk_Claw_DBL", 0, 0f);
        isAttacking = true;
        agent.isStopped = true;
      }
    } else {
      if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk")) {
        isAttacking = false;
        agent.isStopped = false;
      }
    }

  }

  public void Die(){
    if (false == isDead) {
      GetComponent<Animator>().Play("Dead_G", 0, 0f);
      isDead = true;
      agent.isStopped = true;
    }
  }


}
