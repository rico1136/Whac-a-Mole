using System.Security.AccessControl;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class HighScores
{
        //public variables
        public List<HighScoreEntry> highScoreEntries = new List<HighScoreEntry>();

        //private variables
        
        public HighScores(string HighScoresJson)
        {
            //Return if json doesnt excist or something went wrong
            if (String.IsNullOrEmpty(HighScoresJson)) return;

            HighScores tmp = SerializeFromJson(HighScoresJson);            

            //Get the highscore list from the saved json
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
