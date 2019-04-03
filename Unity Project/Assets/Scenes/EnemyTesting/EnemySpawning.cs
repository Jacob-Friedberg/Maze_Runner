/*  Corbin Schueller
    EnemySpawning.cs
    This script runs the enemy stress test */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject Dragon;
    public Vector3 spawnValues;
    public int startWait;
    int dragonCount = 1;

    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(Dragon, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            dragonCount++;
            Debug.Log("Dragon Count: " + dragonCount);
            yield return new WaitForSeconds(0.000001F);
        }
    }
}
