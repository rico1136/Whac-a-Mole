using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;



public class GameManager : MonoBehaviour
{
    //public variables
    public HighScoreEntry score = new HighScoreEntry(null,0);

    public Button gameStart;

    #region Gamover
    public TMP_InputField nameInput;
    public TMP_Text scoreText;
#endregion

    public float totalTime = 60f;
    public UnityEvent onTimerEnd;
    public MoleController moleController;
    //private variables
    private float timeLeft;
    private bool isRunning;

    #region Unity Voids

    private void OnEnable()
    {
        gameStart.onClick.AddListener(OnGameStartClicked);
        nameInput.onEndEdit.AddListener(SetName);
    }

    private void OnDisable()
    {
        gameStart.onClick.RemoveListener(OnGameStartClicked);
        nameInput.onEndEdit.RemoveListener(SetName);
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
                moleController.EndGame();
                onTimerEnd.Invoke();
                isRunning = false;
                SetScore();
                
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

    //TODO other way
    public void SetName(string name)
    {
        score.playerName = name;
    }
    #endregion

    #region Private Voids
    private void SetScore()
    {
        score.playerScore = moleController.score;
        scoreText.text = score.playerScore.ToString();
    }

    private void OnGameStartClicked()
    {
        gameStart.GetComponentInParent<Canvas>().gameObject.SetActive(false);

        StartTimer();
    }

    #endregion
}