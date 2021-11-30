using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{

    //Question and text elements
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly;
    [Header("Buttons")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;


    
    void Start()
    {
        GetNextQuestion();
        timer = FindObjectOfType<Timer>();
       

    }

    void Update() 
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion == true)
        {
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        
    }

    
    //Highlight correct answer when an answer is selected
    public void OnAnswerSelected(int index)
    {
        Image buttonImage;

        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            questionText.text = "Incorrect!  The correct answer is: \n" + question.GetAnswer(correctAnswerIndex);
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;  
        }
        SetButtonState(false);
        timer.CancelTimer();
    }

    
    void DisplayQuestion() 
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++) 
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
      
        }
    }

    //Reactivate buttons and set next question
    
    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    //Toggle button interactivity on or off
    void SetButtonState(bool state) 
    {
        for (int i = 0; i < answerButtons.Length; i++) 
            {
                Button button = answerButtons[i].GetComponent<Button>();
                button.interactable = state;
            }
    }

    void SetDefaultButtonSprites() 
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
