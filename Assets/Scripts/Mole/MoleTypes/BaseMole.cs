using UnityEngine;
using System.Collections;

namespace Mole
{
    public class BaseMole : Mole
    {

        public float quickHideDuration = .25f;

        public override int Probability => 5;
        public override int Points => 1;

        public Material HitMaterial;
        public override void OnMoleClicked()
        {
            GetComponentInChildren<Renderer>().material = HitMaterial;
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