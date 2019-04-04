using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonID : MonoBehaviour
{
    public int id;
    [SerializeField] private GameObject dragonAttackTrigger;
    
    public GameObject returnDragonAttackTrigger(){
        return dragonAttackTrigger;
    }
    public int returnID(){
        return id;
    }
}
