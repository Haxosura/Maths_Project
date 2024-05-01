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
    public int MaxPointsSpawn;

    public int PlayerPoints = 0;
    public int GameEndPoints;
    [SerializeField] TMP_Text Points;


    public void PointIncrease()
    {
        Points.text = "Points: " + PlayerPoints;
    }


    bool TimerStart = false;

    //float Time;
    [SerializeField] float Minutes;
    [SerializeField] float Seconds;

    [SerializeField] TMP_Text Timer;


    // Start is called before the first frame update
    void Start()
    {
        PointIncrease();

        TimerStart = true;
        //Time = 60; Minutes = 5; Seconds = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPoints >= GameEndPoints)
        {
            Debug.Log("EndGame: Win");
        }


        if (TimerStart)
        {
            /*Time -= 0.1f;
            if (Time <= 0)
            {
                Time = 60;
                Seconds -= UnityEngine.Time.deltaTime;
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
            }*/

            Seconds -= UnityEngine.Time.deltaTime;
            if (Seconds < 0)
            {
                if (Minutes <= 0)
                {
                    TimerStart = false;
                    Debug.Log("EndGame: Lose");
                }
                else
                {
                    Seconds += 60;
                    Minutes -= 1;
                }
            }
            Timer.text = "Timer: " + Minutes.ToString("00") + ":" + Seconds.ToString("00");
        }
    }
}
