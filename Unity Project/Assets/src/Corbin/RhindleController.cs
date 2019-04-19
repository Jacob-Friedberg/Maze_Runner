/* RhindleController.cs
Corbin
This script is responsible for implemeting a "Concrete Product" for the
Factory design pattern. In this case, it is the dragon Rhindle which inherits
from the abstact class BaseDragon. Because BaseDragon implements the IDragon
interface this "ConcreteProduct" uses also uses the methods defined in IDragon.
This "ConcreteProduct" chooses to override some of the virtual IDragon methods
defined in BaseDragon. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhindleController : BaseDragon
{
    // DragonPrefab is the specific dragon object associated with this
    // particular "Concrete Product". In this case it is the Rhindle prefab object.
    [SerializeField] private GameObject dragonPrefab;
    // This vector dictates the spawn location for Rhindle depending on the scene
    [SerializeField] private Vector3 rhindleSpawnLocations;

    // Spawn() overrides the IDragon methods implemented in BaseDragon
    // and intializes the dragon in the scene and initializes variables
    // from base dragon that are specific dragon depdendent
    public override void spawn()
    {
        type = DragonTypes.rhindle;
        dragonObject = Instantiate(dragonPrefab, rhindleSpawnLocations, dragonPrefab.transform.rotation);
        agent = dragonObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        dragonHeadObject = GameObject.Find("RhindleHead");
        playerTarget = GameObject.FindGameObjectWithTag("Target");
        dragonHeadObject.GetComponent<DragonHead>().Init(this);
        audioSourceComponent = dragonObject.GetComponent<AudioSource>();
    }

    // TakeDamage() overrides the IDragon method implemented in BaseDragon
    // and decrements a dragon's health depending on what specific dragon
    // the IDragon is
    public override IEnumerator takeDamage()
    {
        health -= 25;
        yield return damageBufferDelay();
    }
}