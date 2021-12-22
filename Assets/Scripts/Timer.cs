using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30.0f;
    [SerializeField] float timeToShowCorrectAnswer = 10.0f;

    public bool isAnsweringQuestion;
    float currTimerValue;
    public bool loadNextQuestion;
    public float fillFraction;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer() 
    {
        currTimerValue = 0;
    }
    void UpdateTimer() 
    {
        currTimerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (currTimerValue > 0)
            {
                fillFraction = currTimerValue / timeToCompleteQuestion;
            }
            else 
            {
                isAnsweringQuestion = false;
                currTimerValue = timeToShowCorrectAnswer;
            }
        }
        else 
        {
            if (currTimerValue <= 0)
            {
                isAnsweringQuestion = true;
                currTimerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
            else 
            {
                fillFraction = currTimerValue / timeToShowCorrectAnswer;
                loadNextQuestion = false;
            }
           

        }
    }
}
