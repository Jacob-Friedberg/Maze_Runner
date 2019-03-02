using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHead : MonoBehaviour
{
  public GameObject dragon;
  void OnTriggerEnter (Collider col)
  {
    if (col.gameObject.CompareTag("Sword"))
    {

      dragon.GetComponent<DragonAI>().Die();
      // Debug.Log ("DRAGON DEATH");
    }
  }
}
