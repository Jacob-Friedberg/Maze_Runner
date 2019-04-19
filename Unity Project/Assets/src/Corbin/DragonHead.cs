/* DragonHead.cs
Corbin
This script is responsible for calling the TakeDamage() method
of an IDragon instance when the sphere collider in the dragon's head 
registers a collision with the sword by having a reference to an 
instance of a IDragon interface that has an instance of this class in it.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHead : MonoBehaviour
{
    
    private IDragon controller;

    // Assign an IDragon instance to a DragonHead instance
    public void Init(IDragon dragon)
    {
        controller = dragon;
    }
    // Tell IDragon instance to take damage
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Sword") == true)
        {
            StartCoroutine(controller.takeDamage());
        }
    }
}
