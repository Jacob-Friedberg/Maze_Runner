/* DragonSpawner.cs
Corbin
This script implements the "Creator" and "Concrete Creator" of the
factory design pattern along with implementing a singleton pattern.  
DragonSpawner is the "Creator" class and controls the dragon objects by
accessing the IDragon methods of the returned dragons. DragonFactory
is the "Concrete Creator" which is actually in charge of returning a
requested IDragon object specified by dragon type. DragonFactory uses
a singleton patttern. This is because there need only ever be a single
DragonFactory instance that returns IDragons. DragonTypes in an 
enumeration that simply assigns a specific dragon to an integer that is
used in the DragonFactory's GetDragon() method*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

// This class implements the "Creator" of the factory pattern.
public class DragonSpawner : MonoBehaviour
{
    // Variable declarations and definitions

    // Variable to allow navmesh to be dynamically generated at runtime
    public NavMeshSurface surface;
    // SceneID controls the spawn locations of dragons.
    [SerializeField] private int _sceneID;
    public int sceneID{
        get{
            return _sceneID;
        }
        set{
            if(value < 0){
                _sceneID = 0;
            }
            else if(value > 2){
                _sceneID = 2;
            }
            else{
                _sceneID = value;
            }
        }
    }

    // difficulty specifies the # of dragons to be spawned.
    [SerializeField] private int _difficulty;
    public int difficulty{
        get{
            return _difficulty;
        }
        set{
            if(value < 0){
                _difficulty = 0;
            }
            else if(value > 2){
                _difficulty = 2;
            }
            else{
                _difficulty = value;
            }
        }
    }

    // dragons is a list of IDragons objects that use the 
    // IDragon interface
    private List<IDragon> dragons = new List<IDragon>();
    // dFactory is set to the DragonFactory singleton instance
    DragonFactory dFactory = DragonFactory.getInstance();

    // Start first dynamically generates the navemesh for the level
    // Next get's # of dragons specified by the difficulty.
    // Then spawns the dragons in locations specified by SceneID
    // And finally tells them to move around until they die. 
    private void Start()
    {
        surface.BuildNavMesh();
        for (int i = 0; i <= difficulty; i++)
        {
            dragons.Add(dFactory.getDragon((DragonTypes)i,sceneID));
        }
        foreach (IDragon item in dragons)
        {
            item.addDragonSounds();
            item.spawn(sceneID);
        }
        foreach (IDragon item in dragons)
        {
            StartCoroutine(item.behave());
        }
    }
}

// This class implements the "Concrete Creator" of the factory pattern
public class DragonFactory
{
    // DragonSpawnerObject is assigned to the "DragonSpawner" object in scene
    // which holds the information about the 3 specific dragons: Grundle, Yorgle,
    // and Rhindle
    static private GameObject dragonSpawnerObject;
    // instance is the Singleton instance of DragonFactory
    static private DragonFactory instance;
    private DragonFactory(){
    }
    // getInstance returns the singleton instance of DragonFactory
    public static DragonFactory getInstance(){
        if(instance == null){
            instance = new DragonFactory();
        }
        return instance;
    }
    
    // getDragon returns a specific IDragon object which is found on
    // the "DragonSpawner" game object based on an inputed DragonType
    public IDragon getDragon(DragonTypes dragonType, int sceneID){
        if(dragonSpawnerObject == null){
            dragonSpawnerObject = GameObject.Find("DragonSpawner");
        }
        switch(dragonType){
            case DragonTypes.grundle:
                return dragonSpawnerObject.GetComponent<GrundleController>();
            case DragonTypes.yorgle:
                return dragonSpawnerObject.GetComponent<YorgleController>();
            case DragonTypes.rhindle:
                return dragonSpawnerObject.GetComponent<RhindleController>();
            default:
                return dragonSpawnerObject.GetComponent<GrundleController>();
        }
    }
}

// An enumeration associating an integer with a specific dragon
public enum DragonTypes
{
    grundle = 0,
    yorgle,
    rhindle
};
