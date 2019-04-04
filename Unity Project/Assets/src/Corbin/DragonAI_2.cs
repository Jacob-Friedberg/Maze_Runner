/* DragonAI.cs
Corbin and Conrad
This script controls the dragon's movement, movement animation, 
attacking, attacking animation and the dragon's health */

using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class DragonAI_2 : MonoBehaviour
{
  [SerializeField] private float attackDistance;
  [SerializeField] private GameObject target;
  [SerializeField] private GameObject DragonAI;
  [SerializeField] private GameObject grundle;
  [SerializeField] private GameObject yorgle;
  [SerializeField] private GameObject rhindle;
  [SerializeField] private Vector3[] scene1DragonSpawnLocations = new Vector3[3];
  [SerializeField] private Vector3[] scene2DragonSpawnLocations = new Vector3[3];
  [SerializeField] private Vector3[] scene3DragonSpawnLocations = new Vector3[3];
  // difficulty is to be set between 1 - 3 with 1 being Dr. BC mode and 3 being the hardest difficulty
  public int difficulty;
  // sceneID is to know which unique dragon to spawn in
  public int sceneID;
  protected int[] dragonHealth = new int[3];
  protected int swordDamage;
  protected NavMeshAgent[] agent = new NavMeshAgent[3];
  protected bool[] isAttacking = new bool[3];
  protected bool[] isDead = new bool[3];
  protected GameObject[] dragonObject = new GameObject[3];
  protected GameObject[] attackTrigger = new GameObject[3];
  private int numDragons;
  
  void Start()
  {
    switch (sceneID)
    {
        case 0:
        switch (difficulty)
        {
            case 1:
            numDragons = 1;
            break;
            case 2:
            numDragons = 2;
            break;
            case 3:
            numDragons = 3;
            break;
            default:
            break;
        }
        break;
        case 1:
        switch (difficulty)
        {
            case 1:
            numDragons = 1;
            break;
            case 2:
            numDragons = 2;
            break;
            case 3:
            numDragons = 3;
            break;
            default:
            break;
        }
        break;
        case 2:
        switch (difficulty)
        {
            case 1:
            numDragons = 1;
            break;
            case 2:
            numDragons = 2;
            break;
            case 3:
            numDragons = 3;
            break;
            default:
            break;
        }
        break;
        default:
        break;
    }
    SpawnDragons();
    // Initialize difficulty settings
    switch (difficulty)
    {
        case 1:
        swordDamage = 100;
        break;
        case 2:
        swordDamage = 50;
        break;
        case 3:
        swordDamage = 25;
        break;
        default:
        swordDamage = 100;
        break;
    }
  }

  void Update()
  {
    for (int i = 0; i < numDragons; i++)
    {
        if (false == isAttacking[i] && false == isDead[i]) 
        {
          agent[i].SetDestination(target.transform.position);

            if (Vector3.Distance(attackTrigger[i].transform.position, target.transform.position) < attackDistance)
            {
              switch ((int)Random.Range(0.0f, 2.99f))
                {
                  case 0:
                  dragonObject[i].GetComponent<Animator>().Play("Atk_Claw_DBL", 0, 0f);
                  break;
                  case 1:
                  dragonObject[i].GetComponent<Animator>().Play("Atk_Claw_L", 0, 0f);
                  break;
                  case 2:
                  dragonObject[i].GetComponent<Animator>().Play("Atk_Claw_R", 0, 0f);
                  break;
                  default:
                  break;
                }
            isAttacking[i] = true;
            agent[i].isStopped = true;
          }
      } 
      else if (dragonObject[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk")) 
        { 
          isAttacking[i] = false;
          agent[i].isStopped = false;
        }
    }
  }
  // This function subtracts damage from the dragon health
  // and despawns the dragon if all the heath is zero
  public void TakeDamage(int x)
  {
    Debug.Log("TakeDamage() called");
    dragonHealth[x] = dragonHealth[x] - swordDamage;
    if (dragonHealth[x] <= 0 && isDead[x] == false) {
      isDead[x] = true;
      Debug.Log("Dragon dying");
      dragonObject[x].GetComponent<Animator>().Play("Dead_G", 0, 0f);
      isDead[x] = true;
      agent[x].isStopped = true;
      // Wait 5 seconds and then despawn the dragon
      StartCoroutine(DragonDespawnWait(x));
    }
  }
  // This function waits for 5 seconds and then despawns the dragon
  private IEnumerator DragonDespawnWait(int x)
  {
    Debug.Log("Waiting for 5 seconds");
    yield return new WaitForSecondsRealtime(5);
    Debug.Log("Waited for 5 seconds");
    //Destroy(dragonObject[x]); 
  }

  private void SpawnDragons(){
    switch (sceneID)
      {
        case 0:
          for (int i = 0; i < numDragons; i++)
              {

                dragonObject[i] = Instantiate(yorgle, scene1DragonSpawnLocations[i], gameObject.transform.rotation);
              }
        break;
        case 1:
          for (int i = 0; i < numDragons; i++)
              {
                dragonObject[i] = Instantiate(yorgle, scene2DragonSpawnLocations[i], gameObject.transform.rotation);
              }
        break;
        case 2:
          for (int i = 0; i < numDragons; i++)
              {
                dragonObject[i] = Instantiate(yorgle, scene3DragonSpawnLocations[i], gameObject.transform.rotation);
              }
        break; 
        default:
        Debug.Log("No dragons spawned");
        break;
      }
    for (int i = 0; i < numDragons; i++)
    {
      agent[i] = dragonObject[i].GetComponent<NavMeshAgent>();
      attackTrigger[i] = dragonObject[i].GetComponent<DragonID>().returnDragonAttackTrigger();
      dragonObject[i].GetComponent<DragonID>().id = i;
      isDead[i] = false;
      dragonHealth[i] = 100;
    }
  }
}
