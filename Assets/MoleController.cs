using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour
{
    public List<Mole> moles = new List<Mole>();

    private List<Mole> currentMoles = new List<Mole>();

    public bool started = false;

    public float score; 
    public void StartGame()
    {
        foreach (Mole mole in moles)
        {
            mole.Hide();
        }
        currentMoles.Clear();
        score = 0;

        started = true;
    }

    public void EndGame()
    {
        started = false;
        foreach (Mole mole in currentMoles)
        {
            mole.Hide();
        }
        currentMoles.Clear();
    }
    
    private void Update() {
        if (started)
        {
            //TODO Change this 1 over time
            if (currentMoles.Count < 1)
            {
                int index = Random.Range(0, moles.Count);
                currentMoles.Add(moles[index]);
                moles[index].ShowThenHide();
            }
        }
    }

    public void RemoveMole(Mole mole)
    {
        currentMoles.Remove(currentMoles.Find(x => x == mole));
    }
}
