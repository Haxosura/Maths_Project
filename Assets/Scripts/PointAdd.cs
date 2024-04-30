using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAdd : MonoBehaviour
{
    public int AddPoint = 100;

    public void AddPoints()
    {
        GamePlayValues.instance().PlayerPoints += AddPoint;
        GamePlayValues.instance().PointIncrease();
    }
}
