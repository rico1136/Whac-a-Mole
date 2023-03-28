using System.Collections.Generic;
using System;
using UnityEngine;

public class HighScores
{
        //public variables
        public List<HighScoreEntry> highScoreEntries;

        //private variables
        
        public HighScores(string HighScoresJson)
        {
            //Create new list if highscorejson is empty
            if (HighScoresJson == null)
            {
                highScoreEntries = new List<HighScoreEntry>();
                return;
            }

            //Get the highscore list from the saved json
            HighScores tmp = JsonUtility.FromJson<HighScores>(HighScoresJson);
            this.highScoreEntries = tmp.highScoreEntries;
        }
        
        #region Unity Voids 

        #endregion
    
        #region Public Voids
        private string SerializeToJson()
        {
            string json = JsonUtility.ToJson(this);
            return json;
        }
        private void AddHightScoreEntry(HighScoreEntry entryToAdd)
        {
            //Add entry to the highScoreList
            highScoreEntries.Add(entryToAdd);

            //Save the new list in playerprefs
            PlayerPrefs.SetString("HighScores", SerializeToJson());
        }
        #endregion
    
        #region Private Voids
        #endregion
       
}
