using System.Globalization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreEntryController : MonoBehaviour
{
    public HighScoreEntry entry;
    public TMP_Text name;
    public TMP_Text score;
    private void Start() {
        if (entry == null) 
        {
            Destroy(this.gameObject);
            return;
        }
        
            name.text = entry.playerName;
            score.text = $"Score: {entry.playerScore}"; 
    }
}
