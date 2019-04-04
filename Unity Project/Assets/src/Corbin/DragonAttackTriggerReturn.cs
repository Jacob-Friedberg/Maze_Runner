using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttackTriggerReturn : MonoBehaviour
{
    [SerializeField] private GameObject dragonAttackTrigger;
    
    public GameObject returnDragonAttackTrigger(){
        return dragonAttackTrigger;
    }
}
