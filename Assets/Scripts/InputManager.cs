using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // LayerMask to define which layers the raycast should hit
    public LayerMask layerMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if left mouse button is pressed
        {
            // Cast a ray from the mouse position 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Check if the ray hits an object with the IClickable interface
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                IClickable clickable = hit.collider.GetComponentInParent<IClickable>();
                
                if (clickable != null)
                {
                    clickable.OnClicked(); // Call the OnPressed method of the IClickable object
                }
            }
        }
    }
}
