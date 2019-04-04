/* DragonHead.cs
Corbin and Conrad
This script is responsible for triggering the TakeDamage function
when the collider sphere in the dragon's head registers a collision
with the sword. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHead : MonoBehaviour
{
  public GameObject dragon;
  private void Start()
  {
    dragon = GameObject.Find("DragonAI_2");
  }
  void OnTriggerEnter (Collider col)
  {
    Debug.Log("OnTriggerEnter() called");
    if (col.gameObject.CompareTag("Sword"))
    {
      Debug.Log("Sword Dragon Collision detected");
      dragon.GetComponent<DragonAI_2>().TakeDamage();
      StartCoroutine(DragonDamageWait());
    }
  }

  // This function waits for one second after the dragon takes
  // damage so player cannot insta-kill dragon
  private IEnumerator DragonDamageWait(){
    yield return new WaitForSecondsRealtime(1);
  }
}
