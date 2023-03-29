using System;
using UnityEngine;

[Serializable]
public class HighScoreEntry
{
    public string playerName;
    public int playerScore;

    public HighScoreEntry(string PlayerName, int PlayerScore)
    {
        playerName = PlayerName;
        playerScore = PlayerScore;
    }
}
