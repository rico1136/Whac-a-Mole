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
        highScores = new HighScores(PlayerPrefs.GetString("HighScores", null));

        highScores.highScoreEntries = highScores.highScoreEntries.OrderBy(x => -x.playerScore).ToList();

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

        private string SerializeToJson()
        {
            Debug.Log(JsonUtility.ToJson(highScores));
            string json = JsonUtility.ToJson(highScores);
            return json;
        }
        #endregion
}
