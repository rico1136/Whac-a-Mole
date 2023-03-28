using System.Collections;
using UnityEngine;

public class Mole : MonoBehaviour, IClickable
{
    private Vector3 startPos = new Vector3(0,-1,0); 
    private Vector3 endPos = Vector3.zero; 
    private Renderer renderer;
    public bool active = false;
    public float upDuration = .5f;
    public float duration = 1;
    public Material defaultmat, red;
    public MoleController moleController;
private void Start() {
    renderer = transform.GetComponent<Renderer>();
    defaultmat = renderer.material;
    //StartCoroutine(ShowHide(startPos,endPos));
}

public void ShowThenHide()
{
    renderer.material = defaultmat;
    StartCoroutine(ShowHide(startPos,endPos));
}

public void OnClicked()
{
    StopAllCoroutines();
    transform.GetComponent<Renderer>().material = red;
    Hide();

    moleController.score ++;
}

public void Hide()
{
    moleController.RemoveMole(this);
    transform.localPosition = startPos;
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
   
        Hide();

        yield return null;
    }
}
