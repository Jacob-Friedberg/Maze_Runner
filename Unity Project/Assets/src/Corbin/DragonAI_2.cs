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
    }
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
        switch ((int)Random.Range(0.0f, 2.99f))
        {
            case 0:
            dragonObject.GetComponent<Animator>().Play("Atk_Claw_DBL", 0, 0f);
            break;
            case 1:
            dragonObject.GetComponent<Animator>().Play("Atk_Claw_L", 0, 0f);
            break;
            case 2:
            dragonObject.GetComponent<Animator>().Play("Atk_Claw_R", 0, 0f);
            break;
            default:
            break;
        }
        
        isAttacking = true;
        agent.isStopped = true;
      }
    } else if (dragonObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk")) 
    { 
        isAttacking = false;
        agent.isStopped = false;
    }
  }
  // This function subtracts damage from the dragon health
  // and despawns the dragon if all the heath is zero
  public void TakeDamage()
  {
    Debug.Log("TakeDamage() called");
    dragonHealth = dragonHealth - swordDamage;
    if (dragonHealth <= 0 && isDead == false) {
      isDead = true;
      Debug.Log("Dragon dying");
      dragonObject.GetComponent<Animator>().Play("Dead_G", 0, 0f);
      isDead = true;
      agent.isStopped = true;
      // Wait 5 seconds and then despawn the dragon
      StartCoroutine(DragonDespawnWait());
    }
  }
  // This function waits for 5 seconds and then despawns the dragon
  private IEnumerator DragonDespawnWait()
  {
    Debug.Log("Waiting for 5 seconds");
    yield return new WaitForSecondsRealtime(5);
    Debug.Log("Waited for 5 seconds");
    Destroy(dragonObject);
    Destroy(DragonAI);  
  }

  private void SpawnDragons(){
    switch (sceneID)
      {
        case 0:
        //grundle = Instantiate(grundle, new Vector3(grundleXCoordinate, grundleYCoordinate, grundleZCoordinate), gameObject.transform.rotation);
        dragonObject = grundle;
        break;
        case 1:
        //yorgle = Instantiate(yorgle, new Vector3(yorgleXCoordinate, yorgleYCoordinate, yorgleZCoordinate), gameObject.transform.rotation);
        dragonObject = yorgle;
        break;
        case 2:
        //rhindle = Instantiate(rhindle, new Vector3(rhindleXCoordinate, rhindleYCoordinate, rhindleZCoordinate), gameObject.transform.rotation);
        dragonObject = rhindle;
        break; 
        default:
        Debug.Log("UniqueDragons: Invalid scene ID");
        break;
      }
    agent = dragonObject.GetComponent<NavMeshAgent>();
    // Select attackTrigger object on dragon depending on scene
    switch(sceneID){
      case 0:
      attackTrigger = GameObject.Find("GrundleAttackZone");
      break;
      case 1:
      attackTrigger = GameObject.Find("YorgleAttackZone");
      break;
      case 2:
      attackTrigger = GameObject.Find("RhindleAttackZone");
      break;
      default:
      break;
    }
  }
}
