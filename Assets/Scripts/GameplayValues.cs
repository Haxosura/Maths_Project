using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GamePlayValues : MonoBehaviour
{
    public static GamePlayValues instance()
    {
        return GameObject.Find("GameMode").GetComponent<GamePlayValues>();
    }

    public int PointsSpawned;

    public int PlayerPoints = 0;
    public int MaxPoints;
    public TMP_Text Points;

    public void PointIncrease()
    {
        Points.text = "Points: " + PlayerPoints;
    }


    bool TimerStart = false;

    float Time;
    public float Minutes;
    public float Seconds;

    public TMP_Text Timer;
    

    // Start is called before the first frame update
    void Start()
    {
        PointIncrease();

        TimerStart = true;
        Time = 60; Minutes = 5; Seconds = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPoints >= MaxPoints)
        {
            Debug.Log("EndGame: Win");
        }


        if (TimerStart)
        {
            Time -= 0.1f;
            if (Time <= 0)
            {
                Time = 60;
                Seconds -= 1;
                if (Seconds <= 0)
                {
                    Minutes -= 1;
                    if (Minutes <= 0)
                    {
                        TimerStart = false;
                        Debug.Log("EndGame: Lose");
                    }
                    else
                    {
                        Seconds = 59;
                    }
                }
            }
            Timer.text = "Timer: " + Minutes.ToString("00") + ":" + Seconds.ToString("00");
        }
    }
}
