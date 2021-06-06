using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TMP_Text StartMenuBestTime;
    public TMP_Text GameOverMenuBestTime;
    public TMP_Text timeCounterText;
    public TMP_Text currentRunText;
    private float _timeCounter = 0.0f;
    private float _bestTime = 0.0f;
    private GameBehavior gameManager;
    private bool _isGameRunning = false;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        _bestTime = 3599.0f;
        StartMenuBestTime.text = FloatTimeToString(_bestTime);
        timeCounterText.text = "00:00";
        _timeCounter = 0.0f;
    }

    void FixedUpdate()
    {
        if (_isGameRunning)
        {
            _timeCounter += Time.fixedDeltaTime;
            timeCounterText.text = FloatTimeToString(_timeCounter);
        }
    }

    private string FloatTimeToString(float timeCounter)
    {
        string time = "";
        int minutes = (int)timeCounter / 60;
        int seconds = (int)timeCounter % 60;

        if (minutes < 10)
            time = "0" + minutes + ":";
        else
            time = minutes + ":";

        if (seconds < 10)
            time += "0" + seconds;
        else
            time += seconds;

        return time;
    }

    public void StartCounting()
    {
        _isGameRunning = true;
    }
    public void StopCounting()
    {
        _isGameRunning = false;
        SetBestTimeAndCurrentRunTime();
    }
    public void SetBestTimeAndCurrentRunTime()
    {
        if (_timeCounter < _bestTime)
        {
            _bestTime = _timeCounter;
            StartMenuBestTime.text = FloatTimeToString(_bestTime);
            GameOverMenuBestTime.text = FloatTimeToString(_bestTime);
        }
        currentRunText.text = FloatTimeToString(_timeCounter);
    }

    public void ResetCounter()
    {
        _timeCounter = 0f;
    }
}
