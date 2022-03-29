using UnityEngine;

public class LinearSaw : LinearMovemnet
{
    [SerializeField] private float speed,speedRotation;
    float rotate = 0f;


    private void Update()
    {
        movement(movePoint[getIndex()], speed);
        if (rotate >= 360f) rotate = 0;
        rotate += speedRotation * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, rotate));
    }
}