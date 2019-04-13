using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] protected GameObject dragon;
    protected int dragonHealth;
    protected int swordDamage;
    protected UnityEngine.AI.NavMeshAgent agent;
    protected bool isAttacking = false;
    protected bool isDead = false;
    protected string name;

    // This function subtracts damage from the dragon health
    // and despawns the dragon if all the heath is zero
    public void TakeDamage(){
        Debug.Log("TakeDamage() called");
        dragonHealth = dragonHealth - swordDamage;

        if (dragonHealth <= 0 && isDead == false) {
          isDead = true;
          Debug.Log("Dragon dying");
          GetComponent<Animator>().Play("Dead_G", 0, 0f);
          isDead = true;
          agent.isStopped = true;
          // Wait 5 seconds and then despawn the dragon
          StartCoroutine(DragonDespawnWait());
        }
  }

  // This function waits for 5 seconds and then despawns the dragon
    private IEnumerator DragonDespawnWait(){
        Debug.Log("Waiting for 5 seconds");
        yield return new WaitForSecondsRealtime(5);
        Debug.Log("Waited for 5 seconds");
        Destroy(dragon);
    }
    
}
