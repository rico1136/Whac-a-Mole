using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : MonoBehaviour
{
    HighScores highScores;


    // Start is called before the first frame update
    void Start()
    {
           highScores = new HighScores(PlayerPrefs.GetString("HighScores", null));
            
    }

    private void FillUI()
    {

    }
}
