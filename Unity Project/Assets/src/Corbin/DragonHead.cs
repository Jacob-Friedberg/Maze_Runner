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
  // void OnTriggerEnter (Collider col)
  // {
  //   if (col.gameObject.CompareTag("Sword"))
  //   {
  //     dragon.GetComponent<DragonAI>().TakeDamage();
  //     yield return new WaitForSeconds(1);
  //   }
  // }
}
