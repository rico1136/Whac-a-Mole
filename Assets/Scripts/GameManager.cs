using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public variables
    public Button gameStart;
    public float totalTime = 60f;
    public UnityEvent onTimerEnd;

    //private variables
    private float timeLeft;
    private bool isRunning;

    #region Unity Voids

    private void OnEnable()
    {
        gameStart.onClick.AddListener(OnGameStartClicked);
    }

    private void OnDisable()
    {
        gameStart.onClick.RemoveListener(OnGameStartClicked);
    }

    void Start()
    {
        timeLeft = totalTime;
    }

    void Update()
    {
        if (isRunning)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                onTimerEnd.Invoke();
                isRunning = false;
            }
        }
    }

    #endregion

    #region Public Voids

    public void StartTimer()
    {
        timeLeft = totalTime;
        isRunning = true;
    }

    #endregion

    #region Private Voids

    private void OnGameStartClicked()
    {
        gameStart.GetComponentInParent<Canvas>().gameObject.SetActive(false);

        StartTimer();
        //TODO start game
    }

    #endregion
}