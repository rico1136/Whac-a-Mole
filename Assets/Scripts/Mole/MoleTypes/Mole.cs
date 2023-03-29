using System.Collections;
using UnityEngine;

namespace Mole
{
    public abstract class Mole : MonoBehaviour, IClickable
    {
        public Vector3 startPos = new Vector3(0, -1, 0);
        public Vector3 endPos = Vector3.zero;

        public float moveDuration = .5f;
        public float upDuration = 1;

        public abstract int Probability { get; }
        public abstract int Points { get; }

        private bool active = true;

        //Set when spawned into world
        [HideInInspector]public MoleController moleController;

        public void ShowThenHide()
        {
            StartCoroutine(ShowHide(startPos, endPos));
        }

        public void OnClicked()
        {
            if (!active) return;
            StopAllCoroutines();
            OnMoleClicked();
            moleController.score += Points;
            active = false;
        }

        public abstract void OnMoleClicked();

        public void Hide()
        {
            moleController.RemoveMole(this);
            Destroy(this.gameObject);
            
            OnMoleHidden();
        }

        public abstract void OnMoleHidden();

        private IEnumerator ShowHide(Vector3 start, Vector3 end)
        {
            float elapsedTime = 0;
            while (elapsedTime < moveDuration)
            {
                transform.localPosition = Vector3.Lerp(start, end, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.localPosition = endPos;

            yield return new WaitForSeconds(upDuration);

            elapsedTime = 0;
            while (elapsedTime < moveDuration)
            {
                transform.localPosition = Vector3.Lerp(end, start, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            Hide();

            yield return null;
        }
    }
}