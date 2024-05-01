using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("EndGame: Lose");
        }
    }
}
