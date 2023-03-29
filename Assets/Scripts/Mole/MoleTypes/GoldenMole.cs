using UnityEngine;
using System.Collections;

namespace Mole
{
    public class GoldenMole : Mole
    {

        public float quickHideDuration = .25f;
        public ParticleSystem hitParticle;
        public override int Probability => 1;
        public override int Points => 10;

        public override void OnMoleClicked()
        {
            hitParticle.Play();
            StartCoroutine(QuickHide(quickHideDuration,startPos, endPos));
        }

        public override void OnMoleHidden()
        {
            //Do nothing
        }
        
        private IEnumerator QuickHide(float hideTime, Vector3 start, Vector3 end)
        {
            yield return new WaitForSeconds(hideTime);
            float elapsedTime = 0;
            while (elapsedTime < hideTime)
            {
                transform.localPosition = Vector3.Lerp(end, start, elapsedTime / hideTime);
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            //Call hide function to remove this mole from moleController
            Hide();
        }
    }
}