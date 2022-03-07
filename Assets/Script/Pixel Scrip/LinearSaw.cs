using UnityEngine;

public class LinearSaw : LinearMovemnet
{
    [SerializeField] private float speed;

    private void Update()
    {
        movement(movePoint[getIndex()], speed);
    }
}