using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public GameObject Target;

    public MyVector Pursuer; // Owner
    public MyVector Evader; // Target

    public MyVector Gap;
    public MyVector NormalizeGap;

    public Vector3 MoveToVector;

    public float Speed = 20.0f;

    public float Range = 20;

    // Update is called once per frame
    void Update()
    {
        FindObject();
        MoveToEvader();
    }

    public void FindObject()
    {
        Target = GameObject.Find("Player");
        Evader = new MyVector(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);

        Pursuer = new MyVector(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    public void MoveToEvader()
    { 
        Gap = MyVector.SubtractVector(Evader, Pursuer);

        if (Gap.GetMegg() >= Range)
        {
            Gap = Gap.Normalize();
            MoveToVector = Gap.ToUnityVector();
            this.transform.position += MoveToVector * Time.deltaTime * Speed;
        }
    }
}
