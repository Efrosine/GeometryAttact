using UnityEngine;

public class Crusher : LinearMovemnet
{
    [SerializeField] private float speedUp, speedDown;

    private void Update()
    {
        if (getIndex() == 0) movement(movePoint[0], speedDown);
        else movement(movePoint[1], speedUp);
    }
}