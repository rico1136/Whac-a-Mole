using System.Collections;
using UnityEngine;

public class Mole : MonoBehaviour
{
    private Vector3 startPos = new Vector3(0,-1,0); 
    private Vector3 endPos = Vector3.zero; 

    public float upDuration = .5f;
    public float duration = 1;

private void Start() {
    StartCoroutine(ShowHide(startPos,endPos));
}

    private IEnumerator ShowHide(Vector3 start, Vector3 end)
    {    

        float elapsedTime = 0;
        while(elapsedTime < upDuration)
{
            transform.localPosition = Vector3.Lerp(start,end,elapsedTime / upDuration);
           elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = endPos;

        yield return new WaitForSeconds(duration);

        elapsedTime = 0;
        while(elapsedTime < upDuration)
        {    

            transform.localPosition = Vector3.Lerp(end,start,elapsedTime / upDuration);
                       elapsedTime += Time.deltaTime;

            yield return null;
        }
   

                transform.localPosition = startPos;

        yield return null;
    }
}
