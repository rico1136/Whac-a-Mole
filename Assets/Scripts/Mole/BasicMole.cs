using System;
using UnityEngine;

public class BasicMole : MonoBehaviour, IClickable
{
    //public variables

    //private variables

    #region Private Variables

    private bool _isClickable;

    #endregion


    #region Unity Voids

    private void Awake()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Public Voids

    [ContextMenu("MoveUp")]
    public void SetInteractable()
    {
        //Move the mole up to be hittable
        Move(transform.up * 1);

        _isClickable = true;
    }

    [ContextMenu("MoveDown")]
    public void MoveDown()
    {
        Move(transform.up * -1);

        //Move the mole down
        _isClickable = false;
    }


    #region Public Voids

    public virtual void Move(Vector3 newPosition)
    {
        //TODO add animation to this function
        transform.position += newPosition;
    }

    //OnClicked Event send by input manager
    public void OnClicked()
    {
        if (_isClickable)
        {
            MoveDown();
        }
    }

    #endregion

    #endregion

    #region Private Voids

    #endregion
}