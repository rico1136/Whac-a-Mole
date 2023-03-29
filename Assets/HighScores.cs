using System.Security.AccessControl;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class HighScores
{
        //the list with all the highscoreEntries
        public List<HighScoreEntry> highScoreEntries = new List<HighScoreEntry>();

        //private variables
        
        public HighScores(string HighScoresJson)
        {
            //Return if json doesnt excist or something went wrong
            if (String.IsNullOrEmpty(HighScoresJson)) return;
            
            //Get the highscore list from the saved json
            HighScores tmp = SerializeFromJson(HighScoresJson); 
            this.highScoreEntries = tmp.highScoreEntries;
        }
        
        #region Unity Voids 

        #endregion
    
        #region Private voids
        private HighScores SerializeFromJson(string json)
        {
            return JsonUtility.FromJson<HighScores>(json);
        }
        
        #endregion
       
}
