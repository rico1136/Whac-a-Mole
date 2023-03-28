using UnityEngine;

public class Mole : MonoBehaviour
{
    #region Private Variables

    private bool _isClickable;

    #endregion

    #region Public  Variables

    public int PointsOnHit { private set; get; }

    #endregion

    public Mole()
    {
    }

    public Mole(int points)
    {
        PointsOnHit = points;
    }

    

    #region Private Voids

    #endregion
}