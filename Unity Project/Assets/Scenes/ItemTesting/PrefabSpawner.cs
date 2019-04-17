using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    float nextSpawnTime;

    [SerializeField]
    GameObject chalicePrefab;

    float spawnDelay = 1;

    float itemCount = .2;


    void Update()
    {

        transform.rotation = Quaternion.Euler(1, 5, 1);

        if (ShouldSpawn())
        { 
            nextSpawnTime = Time.time + spawnDelay;
            Instantiate(chalicePrefab, transform.position, transform.rotation);
            itemCount++;

            Debug.Log("item count: " + itemCount);

        }
    }

    bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}