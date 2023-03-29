using System;
using Mole;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    //public variables
    public Button gameStart;
    public MoleController moleController;
    public float totalTime = 60f;
    public UnityEvent onTimerEnd;
    public HighScoreEntry score = new HighScoreEntry(null,0);
    [HideInInspector]public float timeLeft;


    //private variables
    private bool isRunning;

    #region Gamover

    public TMP_InputField nameInput;
    public TMP_Text scoreText;

    #endregion

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

    //this works for now but could be cleaner
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion

    #region Private Voids
    private void StartTimer()
    { 
        timeLeft = totalTime;
        isRunning = true;
    }

    //TODO this works but could be cleaner
    private void SetName(string name)
    {
        score.playerName = name;
    }
    
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