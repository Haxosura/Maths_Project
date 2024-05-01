using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

[RequireComponent(typeof(PointAdd))]

public class PointCollision : MonoBehaviour
{
    PointAdd AddToPoints;

    public bool PlayerHit = false;

    public void DestroyCollision()
    {
        if (PlayerHit == true)
        { 
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AddToPoints = GetComponent<PointAdd>();
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHit = true;

            AddToPoints.AddPoints();

            GamePlayValues.instance().PointsSpawned -= 1;

            DestroyCollision();
        }
    }
}
