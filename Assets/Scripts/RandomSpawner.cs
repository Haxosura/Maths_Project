using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject SpawnObject;
    public GameObject SpawnArea;
    private Collider AreaBounds;

    Vector3 SpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        AreaBounds = SpawnArea.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePlayValues.instance().PointsSpawned < GamePlayValues.instance().MaxPointsSpawn)
        {
            Debug.Log("Spawn Point");
            Vector3 RandomSpawnPoint = new Vector3(
                Random.Range(
                    AreaBounds.bounds.min.x,
                    AreaBounds.bounds.max.x), 2, 
                Random.Range(
                    AreaBounds.bounds.min.z,
                    AreaBounds.bounds.max.z));

            Instantiate(SpawnObject, RandomSpawnPoint, Quaternion.identity);

            GamePlayValues.instance().PointsSpawned += 1;
        }
    }
}
