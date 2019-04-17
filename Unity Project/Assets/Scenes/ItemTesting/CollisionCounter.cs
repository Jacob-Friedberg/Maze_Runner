using UnityEngine;
using System;

public class CollisionChecker : MonoBehaviour
{
    public int collisionCount = 0;

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Plane"))
            {
                Debug.Log("Failure! collison count: " + collisionCount);
            }

        collisionCount++;
        }
}