using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject Dragon;
    public Vector3 spawnValues;
    public int startWait;
    int DragonCount = 1;




    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    
    void Update()
    {
        
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(Dragon, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            DragonCount++;
            Debug.Log("Dragon Count: " + DragonCount);
            yield return new WaitForSeconds(0.000001F);
        }
    }
}
