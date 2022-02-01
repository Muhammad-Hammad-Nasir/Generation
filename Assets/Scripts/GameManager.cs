using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI counter;
    public float timer;

    private bool isGameStarted;
    private float horizontal;
    private float vertical;
    private float minutes;
    private float seconds;
    private int minLimit = 1;
    private int speed = 10;
    private int i = 0;

    void Start()
    {
        isGameStarted = true;
        Debug.Log("Game Started");
        timer = 130;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            isGameStarted = !isGameStarted;
            if(isGameStarted)
            {
                Debug.Log("Game Started");
            }
            else
            {
                Debug.Log("Game Paused");
            }
        }

        if (isGameStarted && i == 0)
        {
            CubeResize();
            CubeMove();
            CountDown();
            DisplayTime(timer);

            if (timer <= 0)
            {
                isGameStarted = false;
                i++;
                counter.text = "Time: 00:00";
                Debug.Log("Game has Ended.");
            }
        }
    }

    void CubeResize()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (transform.localScale.x > minLimit)
            {
                transform.localScale -= Vector3.one * 0.003f;
            }
        }
        else
        {
            transform.localScale += Vector3.one * 0.003f;
        }
    }

    void CubeMove()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * horizontal * speed);
        transform.Rotate(Vector3.forward * vertical * speed);
    }

    void CountDown()
    {
        timer -= Time.deltaTime;
    }

    void DisplayTime(float time)
    {
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);

        if (seconds < 10 && minutes < 10)
        {
            counter.text = "Time: 0" + minutes + ": 0" + seconds;
        }
        else if (minutes < 10)
        {
            counter.text = "Time: 0" + minutes + ":" + seconds;
        }
        else if (seconds < 10)
        {
            counter.text = "Time: " + minutes + ": 0" + seconds;
        }
        else
        {
            counter.text = "Time: " + minutes + ":" + seconds;
        }
    }
}
