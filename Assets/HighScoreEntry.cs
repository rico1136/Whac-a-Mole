using System;
using UnityEngine;

public class HighScoreEntry
{
    private string _playerName;
    private int _playerScore;

    public HighScoreEntry(string PlayerName, int PlayerScore)
    {
        _playerName = PlayerName;
        _playerScore = PlayerScore;
    }
}
