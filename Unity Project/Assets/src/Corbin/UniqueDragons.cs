using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueDragons : DragonAI_2
{
    public int sceneID;
    [SerializeField] private GameObject grundle;
    [SerializeField] private GameObject yorgle;
    [SerializeField] private GameObject rhindle;
    [SerializeField] private float grundleXCoordinate;
    [SerializeField] private float grundleYCoordinate;
    [SerializeField] private float grundleZCoordinate;
    [SerializeField] private float yorgleXCoordinate;
    [SerializeField] private float yorgleYCoordinate;
    [SerializeField] private float yorgleZCoordinate;
    [SerializeField] private float rhindleXCoordinate;
    [SerializeField] private float rhindleYCoordinate;
    [SerializeField] private float rhindleZCoordinate;

    public static UniqueDragons instance = null;
    private static readonly object padlock = new object();
    UniqueDragons(){
        switch (sceneID)
        {
            case 0:
            grundle = Instantiate(grundle, new Vector3(grundleXCoordinate, grundleYCoordinate, grundleZCoordinate), gameObject.transform.rotation);
            dragonObject = grundle;
            name = "Grundle";
            break;
            case 1:
            yorgle = Instantiate(yorgle, new Vector3(yorgleXCoordinate, yorgleYCoordinate, yorgleZCoordinate), gameObject.transform.rotation);
            dragonObject = yorgle;
            name = "Yorgle";
            break;
            case 2:
            rhindle = Instantiate(rhindle, new Vector3(rhindleXCoordinate, rhindleYCoordinate, rhindleZCoordinate), gameObject.transform.rotation);
            dragonObject = rhindle;
            name = "Rhindle";
            break; 
            default:
            Debug.Log("UniqueDragons: Invalid scene ID");
            name = "Invalid Scene ID";
            break;
        }
    }
    /*/public static UniqueDragons Instance(int sceneID)
    {
        if (instance != null) 
        {
            return instance;
        }
        lock (padlock)
        {
            if (instance == null)
            {
                instance = UniqueDragons(sceneID);
            }
            return instance;
        }
    }*/
}
