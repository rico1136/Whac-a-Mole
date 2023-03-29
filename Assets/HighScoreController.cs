using System.Security.AccessControl;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : MonoBehaviour
{
    public HighScoreEntryController HighScoreEntryPrefab;
    public Transform entryParent;
    HighScores highScores;

    // Start is called before the first frame update
    void Start()
    {
        //Get the highscores from the saved json in playerprefs
        highScores = new HighScores(PlayerPrefs.GetString("HighScores", null));

        //FOR TESTING TODO Remove
        AddHightScoreEntry(new HighScoreEntry("Rico",100));

        //Sort the highscoreEntries by highest first
        highScores.highScoreEntries = highScores.highScoreEntries.OrderBy(x => -x.playerScore).ToList();

        //Spawn a highscoreobject for each entry
        foreach (HighScoreEntry highScoreEntry in highScores.highScoreEntries)
        {
            HighScoreEntryController spawnedEntry = Instantiate(HighScoreEntryPrefab, entryParent);
            spawnedEntry.entry = highScoreEntry;
        }
    }

        #region Public Voids
        
        #endregion
    
        #region Private Voids
        private void AddHightScoreEntry(HighScoreEntry entryToAdd)
        {
            if (highScores.highScoreEntries == null)
            {
                highScores.highScoreEntries = new List<HighScoreEntry>();
            }

            //Add entry to the highScoreList
            highScores.highScoreEntries.Add(entryToAdd);

            //Save the new list in playerprefs
            PlayerPrefs.SetString("HighScores", SerializeToJson());
        }

        //Create a json string from the highscore list
        private string SerializeToJson()
        {
            Debug.Log(JsonUtility.ToJson(highScores));
            string json = JsonUtility.ToJson(highScores);
            return json;
        }
        #endregion
}
