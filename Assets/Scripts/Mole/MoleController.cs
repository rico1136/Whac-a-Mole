using System.Collections.Generic;
using UnityEngine;

namespace Mole
{
    public class MoleController : MonoBehaviour
    {
        public List<Mole> moles = new List<Mole>();
        public List<Transform> moleHoles = new List<Transform>();
        
        private List<Mole> _currentActiveMoles = new List<Mole>();

        public bool started = false;

        public int score;

        public void StartGame()
        {
            _currentActiveMoles.Clear();
            score = 0;
            started = true;
        }

        public void EndGame()
        {
            started = false;
            //todo delete all active moles
        }

        private void Update()
        {
            if (started)
            {
                //TODO Change this 1 over time
                if (_currentActiveMoles.Count < 2)
                {
                    SpawnMoleInRandomHole();
                }
            }
        }

        public void SpawnMoleInRandomHole()
        {
            int index = Random.Range(0, moleHoles.Count);
            Mole spawnedMole = Instantiate(GetRandomMoleType(), moleHoles[index]);
            spawnedMole.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            spawnedMole.moleController = this;
            
            _currentActiveMoles.Add(spawnedMole);
            spawnedMole.ShowThenHide();
        }

        public Mole GetRandomMoleType()
        {
            float[] cumulativeProbabilities = new float[moles.Count];


            float sumOfProbabilities = 0;
            for (int i = 0; i < moles.Count; i++)
            {
                sumOfProbabilities += moles[i].Probability;
                cumulativeProbabilities[i] = sumOfProbabilities;
            }


            float randomValue = Random.Range(0f, sumOfProbabilities);
            

            for (int i = 0; i < moles.Count; i++)
            {
                if (randomValue < cumulativeProbabilities[i])
                {
                    return moles[i];
                }
            }

            return null;
        }

        public void RemoveMole(Mole mole)
        {
            _currentActiveMoles.Remove(_currentActiveMoles.Find(x => x == mole));
        }
    }
}