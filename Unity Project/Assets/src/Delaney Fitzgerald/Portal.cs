/* Portal.cs
   Delaney Fitzgerald
   class to trigger the change of scene on contact with the player*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter (Collision col)
    {
      if (col.gameObject.CompareTag("Control"))
      {
        Debug.Log ("Change Scene Now!");
      }
    }
}
