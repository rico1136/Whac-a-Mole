using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class GameCanvasController : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text score, timer;
    private void Update()
    {
        //parse the time to a more readable time
        string myString = TimeSpan.FromSeconds(gameManager.timeLeft).ToString("ss");     
        timer.text = $"Time left: {myString}";
        
        //Get the score and show it
        score.text = $"Score: {gameManager.moleController.score}";
    }
}
