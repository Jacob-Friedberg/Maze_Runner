/* DragonAI.cs
Corbin and Conrad
This script controls the dragon's movement, movement animation, 
attacking, attacking animation and the dragon's health */

using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class DragonAI : MonoBehaviour
{
  [SerializeField] private float attackDistance;
  private NavMeshAgent agent;
  private bool isAttacking = false;
  private bool isDead = false;


  public GameObject attackTrigger;
  public GameObject target;
  // difficulty is to be set between 1 - 3 with 1 being Dr. BC mode and 3 being the hardest difficulty
  public int difficulty;
  private int dragonHealth;
  private int swordDamage;
  
  void Start()
  {
    agent = this.GetComponent<NavMeshAgent>();
    // Initialize difficulty settings
    switch (difficulty)
    {
        case 1:
        dragonHealth = 100;
        swordDamage = 100;
        break;
        case 2:
        dragonHealth = 100;
        swordDamage = 50;
        break;
        case 3:
        dragonHealth = 100;
        swordDamage = 25;
        break;
        default:
        dragonHealth = 100;
        swordDamage = 100;
        break;
    }
  }

  void Update()
  {
    if (false == isAttacking && false == isDead) 
    {
      agent.SetDestination(target.transform.position);

      if (Vector3.Distance(attackTrigger.transform.position, target.transform.position) < attackDistance)
      {
        switch ((int)Random.Range(0.0f, 3.0f))
        {
            case 0:
            GetComponent<Animator>().Play("Atk_Claw_DBL", 0, 0f);
            break;
            case 1:
            GetComponent<Animator>().Play("Atk_Claw_DBL", 0, 0f);
            break;
            case 2:
            GetComponent<Animator>().Play("Atk_Claw_DBL", 0, 0f);
            break;
            case 3:
            GetComponent<Animator>().Play("Atk_Claw_DBL", 0, 0f);
            break;
            default:
            break;
        }
        
        isAttacking = true;
        agent.isStopped = true;
      }
    } else if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk")) 
    { 
        isAttacking = false;
        agent.isStopped = false;
    }
  }

// This function subtracts damage from the dragon health
// and despawns the dragon if all the heath is zero
  public void TakeDamage(){
    Debug.Log("TakeDamage() called");
    dragonHealth = dragonHealth - swordDamage;

    if (dragonHealth <= 0 && isDead == false) {
      GetComponent<Animator>().Play("Dead_G", 0, 0f);
      isDead = true;
      agent.isStopped = true;
      // Wait 5 seconds and then despawn the dragon
      StartCoroutine(DragonDespawnWait());
      Destroy(this);
    }
  }

  // This function waits for 5 seconds 
  private IEnumerator DragonDespawnWait(){
    yield return new WaitForSeconds(5);
  }
}



